package com.andrey.pzas091.statisticscollection;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.UUID;

import org.xmlpull.v1.XmlPullParser;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Bundle;
import android.util.Xml;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.widget.Toast;

public class MainActivity extends Activity {

	private final int OPEN_FILE = 12;
	
	private ListView lvTest;
	
	private BluetoothAdapter mBluetoothAdapter;
	private final int REQUEST_ENABLE_BT = 16;
	private final int BT_DEVICE = 17;
	private final int ANSWER_REQUEST = 18;
	
	public static BluetoothDevice device;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		lvTest = (ListView)findViewById(R.id.lvTest);
		lvTest.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> a, View parent, int pos, long id) {
				Test item = (Test) lvTest.getAdapter().getItem(pos);
				TestActivity.item = item;
				Intent intent = new Intent(lvTest.getContext(), TestActivity.class);
				startActivity(intent);
			}
			
		});
		showTestList();
	}
	
	private void showTestList() {
		DataBase db = new DataBase(this);
		Test[] data = db.getTests();
		db.close();
		if (data != null) {
			TestArrayAdapter adapter = new TestArrayAdapter(this, data);
			lvTest.setAdapter(adapter);
		}
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == OPEN_FILE && resultCode == RESULT_OK) {
			if (data.hasExtra("path")) {
				String fileName = data.getStringExtra("path");
				try {
					parseXml(fileName);
					showTestList();
				} 
				catch (Exception e) {
					e.printStackTrace();
				}
			}
		}
		if (requestCode == REQUEST_ENABLE_BT && resultCode == RESULT_OK) {
			startClient();
		}
		if (requestCode == BT_DEVICE && resultCode == RESULT_OK) {
			getQuestion();
		}
		if (requestCode == ANSWER_REQUEST && resultCode == RESULT_OK) {
			if (data.hasExtra("result")) {
				String result = data.getStringExtra("result");
				try {
					mmSocket.getOutputStream().write(result.getBytes());
					mmSocket.close();
				} 
				catch (IOException e) {
					e.printStackTrace();
					return;
				}
			}
		}
		super.onActivityResult(requestCode, resultCode, data);
	}
	
	private void parseXml(String fileName) throws Exception {
		XmlPullParser parser = Xml.newPullParser();
        parser.setFeature(XmlPullParser.FEATURE_PROCESS_NAMESPACES, false);
        InputStream in = new FileInputStream(fileName);
        parser.setInput(in, null);
        boolean first = true;
        //Test Data
        String testId = null;
        String testTitle = null;
        String testCreateDate = null;
        //Questions Data
        String questionId = null;
        String questionTestId = null;
        String questionTitle = null;
        String questionType = null;
        String questionVariants = null;
        //Parse XML
        while (parser.next() != XmlPullParser.END_DOCUMENT) {
            if (parser.getEventType() != XmlPullParser.START_TAG) {
                continue;
            }
            String name = parser.getName();
            if (name.equals("Table")) {
            	DataBase db = new DataBase(this);
            	try {
	            	if (first) {
	            		db.addTest(testId, testTitle, testCreateDate);
	            		first = false;
	            	}
            	}
            	catch (Exception ex) {
            		
            	}
            	db.addQuestion(questionId, questionTestId, questionTitle, 
            			questionType, questionVariants);
            	db.close();
            }
            if (parser.next() == XmlPullParser.TEXT) {
                String result = parser.getText();
                if (name.equals("test._id")) {
                	testId = result;
                }
                if (name.equals("test.title")) {
                	testTitle = result;
                }
                if (name.equals("create_date")) {
                	testCreateDate = result;
                }
                if (name.equals("question._id")) {
                	questionId = result;
                }
                if (name.equals("id_test")) {
                	questionTestId = result;
                }
                if (name.equals("question.title")) {
                	questionTitle = result;
                }
                if (name.equals("type")) {
                	questionType = result;
                }
                if (name.equals("variants")) {
                	questionVariants = result;
                }
                parser.nextTag();
            }
        }
        DataBase db = new DataBase(this);
    	db.addQuestion(questionId, questionTestId, questionTitle, 
    			questionType, questionVariants);
    	db.close();
        in.close();
	}
	
	public void bImport_Click(View v) {
        Intent intent = new Intent(this, OpenFileActivity.class);
		startActivityForResult(intent, OPEN_FILE);
	}

	public void bConnect_Click(View view) {
		mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		if (mBluetoothAdapter == null) {
			Toast.makeText(getApplicationContext(), "Не знайдено Bluetooth!", 
					Toast.LENGTH_SHORT).show();
		    return;
		}
		if (!mBluetoothAdapter.isEnabled()) {
		    Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
		    startActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
		}
		else {
			startClient();
		}
	}
	
	private void startClient() {
		BluetoothPoints.mBluetoothAdapter = mBluetoothAdapter;
		Intent intent = new Intent(this, BluetoothPoints.class);
		startActivityForResult(intent, BT_DEVICE);
	}
	
	private BluetoothSocket mmSocket;
	
	private void getQuestion() {
		try {
			mmSocket = device.createRfcommSocketToServiceRecord(new UUID(1, 200));
			mBluetoothAdapter.cancelDiscovery();
		        // Cancel discovery because it will slow down the connection
		        mBluetoothAdapter.cancelDiscovery();
		        try {
		            // Connect the device through the socket. This will block
		            // until it succeeds or throws an exception
		            mmSocket.connect();
		            mmSocket.getOutputStream().write("request".getBytes());
		            InputStream is = mmSocket.getInputStream();
		            if (is.available() > 0) {
		            	byte[] buffer = new byte[is.available()];
		            	is.read(buffer);
		            	AnswerActivity.questions = new String(buffer);
		            	Intent intent = new Intent(this, AnswerActivity.class);
		        		startActivityForResult(intent, ANSWER_REQUEST);
		            }
		        } 
		        catch (IOException connectException) {
		            // Unable to connect; close the socket and get out
		            try {
		                mmSocket.close();
		            } catch (IOException closeException) { }
		            return;
		        }
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}
	/*
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		//getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	*/
}
