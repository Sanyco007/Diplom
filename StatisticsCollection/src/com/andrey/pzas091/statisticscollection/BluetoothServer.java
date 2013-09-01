package com.andrey.pzas091.statisticscollection;

import java.io.IOException;
import java.io.InputStream;

import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.Context;
import android.widget.Toast;

public class BluetoothServer implements Runnable {

	private BluetoothServerSocket server;
	private String question;	
	private Context ctx;
	
	private final String KVDivide = "11key11";
	private final String RecordDivide = "11new11";
	
	private boolean run = true;
	
	public BluetoothServer(BluetoothServerSocket socket, String question, Context ctx) {
		server = socket;
		this.ctx = ctx;
		this.question = question;
	}
	
	public void start() {
		Thread listen = new Thread(this);
		listen.setDaemon(true);
		listen.start();
	}

	@Override
	public void run() {
		while (run) {
			try {
				BluetoothSocket client = server.accept();
				InputStream is = client.getInputStream();
				if (is.available() > 0) {
					byte[] buffer = new byte[is.available()];
					is.read(buffer);
					String data = new String(buffer);
					if (data.equals("request")) {
						byte[] sendData = question.getBytes();
						client.getOutputStream().write(sendData);
					}
					else {
						addToDataBase(data);
					}
				}
			} 
			catch (IOException e) {
				e.printStackTrace();
			}
		}
		
	}
	
	public void stop() {
		run = false;
		try {
			server.close();
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	private void addToDataBase(String text) {
		String[] records = text.split(RecordDivide);
		DataBase db = new DataBase(ctx);
		for (int i = 0; i < records.length; i++) {
			String[] KV = records[i].split(KVDivide);
			String key = KV[0];
			String value = KV[1];
			db.addAnswer(key, value);
		}
		db.close();
		Toast.makeText(ctx, "Отримано дані!", Toast.LENGTH_SHORT).show();
	}
	
}
