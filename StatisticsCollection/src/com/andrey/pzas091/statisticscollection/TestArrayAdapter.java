package com.andrey.pzas091.statisticscollection;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class TestArrayAdapter extends ArrayAdapter<Test> {
	
	public TestArrayAdapter(Context context, Test[] values) {
		super(context, R.layout.row_layout, values);
	}

	@Override
	public View getView(int position, View view, ViewGroup parent) {
		LayoutInflater inflater = 
				(LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		if (view == null) view = inflater.inflate(R.layout.row_layout, parent, false);
		TextView title = (TextView)view.findViewById(R.id.tvTitle);
		TextView date = (TextView)view.findViewById(R.id.tvDate);
		Test item = getItem(position);
		title.setText(item.getTitle());
		date.setText(item.getDate());
		return view;
	}
	
}
