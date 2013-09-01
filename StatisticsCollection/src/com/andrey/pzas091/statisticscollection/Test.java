package com.andrey.pzas091.statisticscollection;

import android.widget.ImageView;

public class Test {

	public int Id;
	private String title;
	private String date;
	private ImageView icon;
	
	public Test(int id, String title, String date) {
		Id = id;
		this.title = title;
		this.date = date;
	}
	
	public String getTitle() {
		return title;
	}
	
	public void setTitle(String title) {
		this.title = title;
	}
	
	public String getDate() {
		return date;
	}
	
	public void setDate(String date) {
		this.date = date;
	}
	
	public ImageView getIcon() {
		return icon;
	}
	
	public void setIcon(ImageView icon) {
		this.icon = icon;
	}

	
}
