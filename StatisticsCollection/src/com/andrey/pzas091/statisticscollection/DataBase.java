package com.andrey.pzas091.statisticscollection;

import java.util.ArrayList;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DataBase {

	private static final String DATABASE_NAME = "testing.db";
	
	private static final String TABLE_TEST = "test";
	private static final String TEST_COLUMN_ID = "_id";
	private static final String TEST_COLUMN_TITLE = "title";
	private static final String TEST_COLUMN_DATE = "create_date";
	
	private static final String TABLE_QUESTION = "question";
	private static final String QUESTION_COLUMN_ID = "_id";
	private static final String QUESTION_COLUMN_ID_TEST = "id_test";
	private static final String QUESTION_COLUMN_TITLE = "title";
	private static final String QUESTION_COLUMN_TYPE = "type";
	private static final String QUESTION_COLUMN_VARIANTS = "variants";
	
	private static final String TABLE_ANSWER = "answer";
	private static final String ANSWER_COLUMN_ID = "_id";
	private static final String ANSWER_COLUMN_ID_QUESTION = "id_question";
	private static final String ANSWER_COLUMN_TEXT = "answer_text";
	
	private static final int DATABASE_VERSION = 1;
	
	private SQLiteDatabase mDatabase = null;
	
	public DataBase(Context context) {
		OpenHelper openHelper = new OpenHelper(context);
		mDatabase = openHelper.getWritableDatabase();
	}
	
	public Test[] getTests() {
		ArrayList<Test> list = new ArrayList<Test>();
		Cursor cursor = mDatabase.rawQuery("SELECT * FROM " + TABLE_TEST, null);
		cursor.moveToFirst();
		if (!cursor.isAfterLast()) {
			do {
				int id = cursor.getInt(0);
				String title = cursor.getString(1);
				String date = cursor.getString(2);
				date = date.replace('T', ' ');
				date = date.substring(0, date.indexOf('+'));
				list.add(new Test(id, title, date));
			} while (cursor.moveToNext());
		}
		cursor.close();
		Test[] array = new Test[list.size()];
		for (int i = 0; i < array.length; i++) {
			array[i] = list.get(i);
		}
		return array;
	}
	
	public String getQuestions(String id_test) {
		String result = "";
		Cursor cursor = mDatabase.query(TABLE_QUESTION, new String[] {
				QUESTION_COLUMN_ID, 
				QUESTION_COLUMN_TITLE, 
				QUESTION_COLUMN_TYPE, 
				QUESTION_COLUMN_VARIANTS}, 
				"id_test = ?", 
				new String[] {id_test}, null, null, null);
		cursor.moveToFirst();
		if (!cursor.isAfterLast()) {
			do {
				int id = cursor.getInt(0);
				String title = cursor.getString(1);
				String type = cursor.getString(2);
				String variants = cursor.getString(3);
				result += id + "`" + title + "`" + type + "`" + variants + "a1b2c3";
			} while (cursor.moveToNext());
		}
		cursor.close();
		return result;
	}
	
	public long addAnswer(String id, String text) {
		ContentValues values = new ContentValues();
		values.put(ANSWER_COLUMN_ID_QUESTION, id);
		values.put(ANSWER_COLUMN_TEXT, text);
		return mDatabase.insert(TABLE_ANSWER, null, values);
	}
	
	public long addTest(String id, String title, String createDate) {
		ContentValues values = new ContentValues();
		values.put(TEST_COLUMN_ID, id);
		values.put(TEST_COLUMN_TITLE, title);
		values.put(TEST_COLUMN_DATE, createDate);
		return mDatabase.insert(TABLE_TEST, null, values);
	}
	
	public long addQuestion(String id, String id_test, String title, String type, String variants) {
		ContentValues values = new ContentValues();
		values.put(QUESTION_COLUMN_ID, id);
		values.put(QUESTION_COLUMN_ID_TEST, id_test);
		values.put(QUESTION_COLUMN_TITLE, title);
		values.put(QUESTION_COLUMN_TYPE, type);
		values.put(QUESTION_COLUMN_VARIANTS, variants);
		return mDatabase.insert(TABLE_QUESTION, null, values);
	}
	
	public void exportData(Exporter exp, int testId) {
		Cursor cursor = mDatabase.rawQuery("SELECT * FROM " + TABLE_ANSWER + " WHERE id_question IN (SELECT _id FROM question WHERE question.id_test = " + testId + ")", null);
		cursor.moveToFirst();
		if (!cursor.isAfterLast()) {
			do {
				int id = cursor.getInt(0);
				int id_question = cursor.getInt(1);
				String text = cursor.getString(2);
				exp.addRow("" + id, "" + id_question, text);
			} while (cursor.moveToNext());
		}
		cursor.close();
		exp.close();
	}
	
	public void close() {
		mDatabase.close();
	}
	
	private class OpenHelper extends SQLiteOpenHelper {

		public OpenHelper(Context context) {
			super(context, DATABASE_NAME, null, DATABASE_VERSION);
		}

		@Override
		public void onCreate(SQLiteDatabase db) {
			String createTest = "CREATE TABLE " + TABLE_TEST + " (" +
					TEST_COLUMN_ID + " INTEGER PRIMARY KEY, " +
					TEST_COLUMN_TITLE + " TEXT, " + 
					TEST_COLUMN_DATE + " DATETIME); ";
			db.execSQL(createTest);
			String createQuestion = "CREATE TABLE " + TABLE_QUESTION + " (" +
					QUESTION_COLUMN_ID + " INTEGER PRIMARY KEY, " +
					QUESTION_COLUMN_ID_TEST + " INTEGER, " + 
					QUESTION_COLUMN_TITLE + " TEXT, " + 
					QUESTION_COLUMN_TYPE + " TEXT, " + 
					QUESTION_COLUMN_VARIANTS + " TEXT); ";
			db.execSQL(createQuestion);
			String createAnswer = "CREATE TABLE " + TABLE_ANSWER + " (" +
					ANSWER_COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
					ANSWER_COLUMN_ID_QUESTION + " INTEGER, " + 
					ANSWER_COLUMN_TEXT + " TEXT); ";
			db.execSQL(createAnswer);
		}

		@Override
		public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
			db.execSQL("DROP TABLE IF EXISTS " + TABLE_TEST);
			db.execSQL("DROP TABLE IF EXISTS " + TABLE_QUESTION);
			db.execSQL("DROP TABLE IF EXISTS " + TABLE_ANSWER);
			onCreate(db);
		}
		
	}
	
}
