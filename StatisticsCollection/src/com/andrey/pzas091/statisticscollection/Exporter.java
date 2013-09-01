package com.andrey.pzas091.statisticscollection;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import android.annotation.SuppressLint;
import android.os.Environment;

public class Exporter {

	private File file;
	private FileWriter writer;
	
	@SuppressLint("SimpleDateFormat")
	public Exporter(String title) throws IOException {
		String sd = Environment.getExternalStorageDirectory().getPath();
		Calendar c = Calendar.getInstance();
		SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		String date = df.format(c.getTime()).replace("-", "").replace(":", "").replace(" ", "_");
		String path = sd + "/testdb/export/" + title.replace(" ", "_") + date + ".xml";
		file = new File(path);
		if (!file.exists()) {
			file.createNewFile();
		}
		writer = new FileWriter(file);
		writer.write("<?xml version=\"1.0\" standalone=\"yes\"?>\r\n");
		writer.write("<DataSet>\r\n");
	}
	
	
	public void addRow(String id, String id_question, String text) {
		try {
			writer.write("  <Row>\r\n");
			writer.write("    <_id>" + id + "</_id>\r\n");
			writer.write("    <id_question>" + id_question + "</id_question>\r\n");
			writer.write("    <answer_text>" + 
					text
					.replace("&", "&amp;")
					.replace("<", "&lt;")
					.replace(">", "&gt;")
					.replace("\"", "&quot;")
					.replace("?", "&euro;") 
					+ "</answer_text>\r\n");
			writer.write("  </Row>\r\n");
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void close() {
		try {
			writer.write("</DataSet>");
			writer.close();
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}
	
}
