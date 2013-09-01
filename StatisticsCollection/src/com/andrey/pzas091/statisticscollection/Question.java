package com.andrey.pzas091.statisticscollection;

public class Question {

	public String Id;
	public String Title;
	public String Type;
	public String[] Variants;
	
	public Question() {
		
	}
	
	public Question(String id, String title, String type, String[] variants) {
		Id = id;
		Title = title;
		Type = type;
		Variants = variants;
	}
	
}
