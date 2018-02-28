package com.example.vincent.studentapp;

/**
 * Created by 0315310 on 2/20/2018.
 */

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

/**
 * Created by Belal on 9/5/2017.
 */

//here for this class we are using a singleton pattern

public class SharedPrefManager {

    //the constants
    private static final String SHARED_PREF_NAME = "studentapp";
    private static final String KEY_USERNAME = "keyusername";
    private static final String KEY_STUDENT_NUMBER = "KEYNUMBER";
    private static final String KEY_AGE = "KEYAGE";
    private static final String KEY_ADDRESS = "KEYADDRESS";
    private static final String KEY_FNAME = "KEYFNAME";
    private static final String KEY_LNAME = "KEYLNAME";
    private static final String KEY_MNAME = "KEYMNAME";
    private static final String KEY_COURSE = "KEYCOURSE";
    private static final String KEY_YEAR = "KEYYEAR";
    private static final String KEY_CAMPUS = "KEYCAMPUS";
    private static final String KEY_COLLEGE = "KEYCOLLEGE";
    private static final String KEY_BALANCE = "KEYBALANCE";
    //private static final String KEY_FNAME = "KEYFNAME";
    //private static final String KEY_GENDER = "keygender";
    //private static final String KEY_ID = "keyid";

    private static SharedPrefManager mInstance;
    private static Context mCtx;

    private SharedPrefManager(Context context) {
        mCtx = context;
    }

    public static synchronized SharedPrefManager getInstance(Context context) {
        if (mInstance == null) {
            mInstance = new SharedPrefManager(context);
        }
        return mInstance;
    }

    //method to let the user login
    //this method will store the user data in shared preferences
    public void userLogin(User user) {
       // User u=new User();
       // u.Test="test";
        SharedPreferences sharedPreferences = mCtx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
       // editor.putInt(KEY_ID, user.getId());
        editor.putString(KEY_USERNAME, user.Username);
        editor.putString(KEY_STUDENT_NUMBER, user.StudentNumber);
        editor.putInt(KEY_AGE, user.Age);
        editor.putString(KEY_FNAME, user.FirstName);
        editor.putString(KEY_MNAME, user.MiddleName);
        editor.putString(KEY_LNAME, user.LastName);
        editor.putString(KEY_ADDRESS, user.Address);
        editor.putFloat(KEY_BALANCE, user.CardBalance);
        editor.putString(KEY_COLLEGE, user.College);
        editor.putString(KEY_CAMPUS, user.Campus);

        editor.putString(KEY_YEAR, user.YearCode);
       editor.putString(KEY_COURSE, user.CourseCode);

        editor.apply();
    }

    //this method will checker whether user is already logged in or not
    public boolean isLoggedIn() {
        SharedPreferences sharedPreferences = mCtx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        return sharedPreferences.getString(KEY_USERNAME, null) != null;
    }

    //this method will give the logged in user
    public User getUser() {
        SharedPreferences sharedPreferences = mCtx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        User u= new User(
                //sharedPreferences.getInt(KEY_ID, -1),
                //sharedPreferences.getString(KEY_USERNAME, null),
                //sharedPreferences.getString(KEY_EMAIL, null),
                //sharedPreferences.getString(KEY_GENDER, null)
        );
        u.StudentNumber=sharedPreferences.getString(KEY_STUDENT_NUMBER, null);
        u.Username=sharedPreferences.getString(KEY_USERNAME, null);
        u.Age=sharedPreferences.getInt(KEY_AGE, 0);
        u.FirstName=sharedPreferences.getString(KEY_FNAME, null);
        u.MiddleName=sharedPreferences.getString(KEY_MNAME, null);
        u.LastName=sharedPreferences.getString(KEY_LNAME, null);
        u.Address=sharedPreferences.getString(KEY_ADDRESS, null);
        u.CardBalance=sharedPreferences.getFloat(KEY_BALANCE, 0);
        u.College=sharedPreferences.getString(KEY_COLLEGE, null);
        u.Campus=sharedPreferences.getString(KEY_CAMPUS, null);
        u.YearCode=sharedPreferences.getString(KEY_YEAR, null);
        u.CourseCode=sharedPreferences.getString(KEY_COURSE, null);
        return u;
    }

    //this method will logout the user
    public void logout() {
        SharedPreferences sharedPreferences = mCtx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.clear();
        editor.apply();
        mCtx.startActivity(new Intent(mCtx, LoginActivity.class));
    }
}