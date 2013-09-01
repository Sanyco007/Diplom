package com.andrey.pzas091.statisticscollection;

import java.util.HashMap;
import java.util.Iterator;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ScrollView;
import android.widget.TextView;

public class AnswerActivity extends Activity {

	public static String questions;
	
	private LinearLayout root;
	private LinearLayout.LayoutParams lp;
	private LinearLayout.LayoutParams hintLp;
	private LinearLayout.LayoutParams lcheckBox;
	private LinearLayout.LayoutParams lEdit;
	
	private HashMap<String, String> hash;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		hash = new HashMap<String, String>();
		lp = new LinearLayout.LayoutParams
				(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT);
		lcheckBox = new LinearLayout.LayoutParams
				(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT);
		hintLp = new LinearLayout.LayoutParams
				(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT);
		lEdit = new LinearLayout.LayoutParams
				(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT);
		lcheckBox.setMargins(0, 2, 0, 0);
		lEdit.setMargins(0, 10, 8, 10);
		setContentView(initialize());
	}
	
	private ScrollView initialize() {
		ScrollView scroll = new ScrollView(getApplicationContext());
		scroll.setLayoutParams(lp);
		root = new LinearLayout(getApplicationContext());
		root.setLayoutParams(lp);
		root.setOrientation(LinearLayout.VERTICAL);
		Question[] array = parseQuestions();
		showView(array);
		scroll.addView(root);
		return scroll;
	}
	
	private void showView(Question[] array) {
		lp.width = LayoutParams.MATCH_PARENT;
		for (int i = 0; i < array.length; i++) {
			TextView t = new TextView(getApplicationContext());
			t.setText(array[i].Title);  
			lp.setMargins(0, 10, 0, 0);
			t.setLayoutParams(lp);
			t.setTextSize(18);
			root.addView(t);
			if (array[i].Type.equals("Singlechoose")) {
				TextView hint = new TextView(getApplicationContext());
				hint.setText("[Виберіть один варіант]"); 
				hint.setLayoutParams(hintLp);
				hint.setTextSize(12);
				root.addView(hint);
				RadioGroup rg = new RadioGroup(getApplicationContext());
				rg.setTag(array[i].Id);
				rg.setLayoutParams(lp);
				for (int j = 0; j < array[i].Variants.length; j++) {
					RadioButton rb = new RadioButton(getApplicationContext());
					rb.setLayoutParams(lcheckBox);
					rb.setText(array[i].Variants[j]);
					rg.addView(rb);
				}
				root.addView(rg);
			}
			if (array[i].Type.equals("Multichoose")) {
				TextView hint = new TextView(getApplicationContext());
				hint.setText("[Виберіть один чи більше варіантів]"); 
				hint.setLayoutParams(hintLp);
				hint.setTextSize(12);
				root.addView(hint);
				for (int j = 0; j < array[i].Variants.length; j++) {
					CheckBox check = new CheckBox(getApplicationContext());
					check.setTag(array[i].Id);
					check.setLayoutParams(lcheckBox);
					check.setText(array[i].Variants[j]);
					if (j == 0) check.setChecked(true);
					root.addView(check);
				}
			}
			if (array[i].Type.equals("Simple")) {
				TextView hint = new TextView(getApplicationContext());
				hint.setText("[Напишість свою відповідь]"); 
				hint.setLayoutParams(hintLp);
				hint.setTextSize(12);
				root.addView(hint);
				EditText edit = new EditText(getApplicationContext());
				edit.setTag(array[i].Id);
				edit.setLayoutParams(lEdit);
				root.addView(edit);
			}
		}	
		Button finish = new Button(getApplicationContext());
		finish.setLayoutParams(lp);
		finish.setText("Завершити");
		finish.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				for (int i = 0; i < root.getChildCount(); i++) {
					View child = root.getChildAt(i);
					if (child.getTag() instanceof String) {
						String id = (String) child.getTag();
						if (child instanceof CheckBox) {
							if (((CheckBox)child).isChecked()) {
								String text = (String)((CheckBox)child).getText();
								if (!hash.containsKey(id)) {
									hash.put(id, text);
								}
								else {
									String tmp = hash.get(id);
									hash.remove(id);
									hash.put(id, tmp + "~" + text);
								}
							}
						}
						if (child instanceof RadioGroup) {
							int checkId = ((RadioGroup) child).getCheckedRadioButtonId();
							RadioButton rb = null;
							for (int j = 0; j < ((RadioGroup) child).getChildCount(); j++) {
								RadioButton tmp = (RadioButton) ((RadioGroup) child).getChildAt(j);
								if (tmp.getId() == checkId) {
									rb = tmp;
									break;
								}
							}
							String text = (String)rb.getText();
							hash.put(id, text);
						}
						if (child instanceof EditText) {
							String text = ((EditText)child).getText().toString();
							hash.put(id, text);
						}
					}
				}
				String result = "";
				Iterator<String> it = hash.keySet().iterator();
				while (it.hasNext()) {
					String key = it.next();
					String values = hash.get(key);
					result += key + "11key11" + values + "11new11";
				}
				Intent data = new Intent();
		        data.putExtra("result", result);
		        setResult(RESULT_OK, data);
		        finish();
			}
		});
		root.addView(finish);
	}
	
	private Question[] parseQuestions() {
		String[] records = questions.split("a1b2c3");
		Question[] array = new Question[records.length];
		for (int i = 0; i < records.length; i++) {
			String[] data = records[i].split("`");
			String id = data[0];
			String title = data[1];
			String type = data[2];
			String[] variants = data[3].split("~");
			array[i] = new Question(id, title, type, variants);
		}
		return array;
	}
	
}
