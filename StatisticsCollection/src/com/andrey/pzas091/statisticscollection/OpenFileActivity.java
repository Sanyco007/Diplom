package com.andrey.pzas091.statisticscollection;

import java.io.File;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class OpenFileActivity extends ListActivity {
	
	private ArrayAdapter<String> adapter;
	private String path;
	
	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {
		String fileName = adapter.getItem(position);
        Intent data = new Intent();
        data.putExtra("path", path + fileName);
        setResult(RESULT_OK, data);
        finish();
	}
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1);
		setListAdapter(adapter);
		String sd = Environment.getExternalStorageDirectory().getPath();
		path = sd + "/testdb/import/";
		File f = new File(path);
		if (!f.exists()) f.mkdirs();
        File[] files = f.listFiles();
        if (files != null) {
	        for(int i = 0; i < files.length; i++) {
	            File file = files[i];
	            adapter.add(file.getName());
	        }
        }
	}
	
}
