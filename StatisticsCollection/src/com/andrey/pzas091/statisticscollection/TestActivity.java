package com.andrey.pzas091.statisticscollection;

import java.io.IOException;
import java.util.UUID;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothServerSocket;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

public class TestActivity extends Activity {

	public static Test item = null;
	
	private final int ANSWER_REQUEST = 10;
	private final int REQUEST_ENABLE_BT = 15;
	
	private TextView tvTestTitle;
	private TextView tvTestDate;
	
	private BluetoothServer server = null;
	
	private BluetoothAdapter mBluetoothAdapter;
	
	private final String KVDivide = "11key11";
	private final String RecordDivide = "11new11";
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_test);
		tvTestTitle = (TextView)findViewById(R.id.tvTestTitle);
		tvTestDate = (TextView)findViewById(R.id.tvTestDate);
		if (item != null) {
			tvTestTitle.setText(item.getTitle());
			tvTestDate.setText(item.getDate());
		}
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == ANSWER_REQUEST && resultCode == RESULT_OK) {
			if (data.hasExtra("result")) {
				String result = data.getStringExtra("result");
				addToDataBase(result);
			}
		}
		if (requestCode == REQUEST_ENABLE_BT && resultCode == RESULT_OK) {
			startServer();
		}
		super.onActivityResult(requestCode, resultCode, data);
	}
	
	private void addToDataBase(String text) {
		String[] records = text.split(RecordDivide);
		DataBase db = new DataBase(this);
		for (int i = 0; i < records.length; i++) {
			String[] KV = records[i].split(KVDivide);
			String key = KV[0];
			String value = KV[1];
			db.addAnswer(key, value);
		}
		db.close();
	}
	
	public void bViewTest_Click(View view) {
		DataBase db = new DataBase(this);
		AnswerActivity.questions = db.getQuestions("" + item.Id);
		db.close();
		Intent intent = new Intent(this, AnswerActivity.class);
		startActivityForResult(intent, ANSWER_REQUEST);
	}
	
	public void bExportToXML_Click(View view) {
		Exporter exp = null;
		try {
			exp = new Exporter(item.getTitle());
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
		DataBase db = new DataBase(this);
		db.exportData(exp, item.Id);
		db.close();
		Toast.makeText(this, "Export succesfull!", Toast.LENGTH_SHORT).show();
	}
	
	public void bStartTest_Click(View view) {
		mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		if (mBluetoothAdapter == null) {
			Toast.makeText(getApplicationContext(), "Не знайдено Bluetooth!", 
					Toast.LENGTH_SHORT).show();
		    return;
		}
		if (server != null) {
			Toast.makeText(getApplicationContext(), "Сервер вже працює...", Toast.LENGTH_SHORT).show();
			return;
		}
		if (!mBluetoothAdapter.isEnabled()) {
		    Intent discoverableIntent = new
		    Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
		    discoverableIntent.putExtra(BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION, 300);
		    startActivityForResult(discoverableIntent, REQUEST_ENABLE_BT);
		}
		else {
			startServer();
		}
	}
	
	private void startServer() {
		try {
			DataBase db = new DataBase(this);
			String question = db.getQuestions("" + item.Id);
			db.close();
			BluetoothServerSocket socket = mBluetoothAdapter.
					listenUsingRfcommWithServiceRecord("DataCollectionApp", new UUID(1, 200));
			server = new BluetoothServer(socket, question, this);
			server.start();
			Toast.makeText(getApplicationContext(), "Сервер запущено!", Toast.LENGTH_SHORT).show();
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Override
	protected void onDestroy() {
		if (server != null) server.stop();
		super.onDestroy();
	}
	
}
