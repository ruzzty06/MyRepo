package com.example.vincent.studentapp;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by 0315310 on 2/6/2018.
 */

public class Accounts extends Fragment {

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //returning our layout file
        //change R.layout.yourlayoutfilename for each of your fragments
        View v= inflater.inflate(R.layout.fragment_accounts, container, false);
        User u=SharedPrefManager.getInstance(getActivity()).getUser();
        TextView studentname = (TextView)v.findViewById(R.id.txtStudentname);
        TextView snum = (TextView)v.findViewById(R.id.txtStudentnumber);
        TextView college = (TextView)v.findViewById(R.id.txtCollege);
        TextView course = (TextView)v.findViewById(R.id.txtCourse);
        TextView year = (TextView)v.findViewById(R.id.txtYear);
        TextView address = (TextView)v.findViewById(R.id.txtAddress);
        TextView age = (TextView)v.findViewById(R.id.txtAge);
        TextView campus = (TextView)v.findViewById(R.id.txtCampus);
        studentname.setText(u.FirstName+" "+u.MiddleName+" "+u.LastName);
        snum.setText(u.StudentNumber);
        college.setText(u.College);
        campus.setText(u.Campus);
        course.setText(u.CourseCode);
        year.setText(u.YearCode);
        address.setText(u.Address);
        age.setText(String.valueOf(u.Age));
        return v;
    }


    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        //you can set the title for your toolbar here for different fragments different titles


        getActivity().setTitle("Student's information");


    }

}
