package com.example.vincent.studentapp;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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
import java.util.HashMap;
import java.util.List;

/**
 * Created by 0315310 on 2/6/2018.
 */

public class Library extends Fragment {
    private Context context;
    public static final int CONNECTION_TIMEOUT = 10000;
    public static final int READ_TIMEOUT = 15000;
    private RecyclerView mRVBooks;
    private AdapterBook mAdapter;
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //returning our layout file
        //change R.layout.yourlayoutfilename for each of your fragments
        context=this.getContext();
        return inflater.inflate(R.layout.fragment_library, container, false);
    }


    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        //you can set the title for your toolbar here for different fragments different titles
        getActivity().setTitle("Library");
        mRVBooks=(RecyclerView)getView().findViewById(R.id.libraryList);
        new Library.AsyncLogin().execute();
    }
    private class AsyncLogin extends AsyncTask<String, String, String> {

        ProgressDialog pdLoading = new ProgressDialog(context);
        HttpURLConnection conn;
        URL url = null;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            //this method will be running on UI thread
            pdLoading.setMessage("\tLoading...");
            pdLoading.setCancelable(false);
            pdLoading.show();

        }

        @Override
        protected String doInBackground(String... params) {

                // Enter URL address where your json file resides
                // Even you can make call to php file which returns json data
                //url = new URL("http://192.168.1.7/test/example.json");
                // url = new URL("http://simplifiedcoding.net/demos/marvel");
                //url = new URL();
            RequestHandler requestHandler = new RequestHandler();

            //creating request parameters
            HashMap<String, String> params1 = new HashMap<>();


            //returing the response

            return requestHandler.sendGetRequest(URLs.rootURL+"api/Library", params1);

        }

        @Override
        protected void onPostExecute(String result) {

            //this method will be running on UI thread
            if(android.os.Debug.isDebuggerConnected())
                android.os.Debug.waitForDebugger();

            pdLoading.dismiss();
            List<DataBook> data=new ArrayList<>();


            try {

                JSONArray jArray = new JSONArray(result);

                // Extract data from json and store into ArrayList as class objects
                for(int i=0;i<jArray.length();i++){
                    JSONObject json_data = jArray.getJSONObject(i);
                    DataBook bookData = new DataBook();
                    bookData.Title= json_data.getString("Title");
                    bookData.BookID= json_data.getString("BookID");
                    bookData.Author= json_data.getString("Author");
                    bookData.Copies= json_data.getString("Copies");
                    //fishData.price= json_data.getInt("createdby");

                    data.add(bookData);
                }

                // Setup and Handover data to recyclerview
                // mRVFishPrice = (RecyclerView)findViewById(R.id.fishPriceList);
                mAdapter = new AdapterBook(context, data);
                mRVBooks.setAdapter(mAdapter);
                mRVBooks.setLayoutManager(new LinearLayoutManager(context));

            } catch (JSONException e) {
                Toast.makeText(context, e.toString(), Toast.LENGTH_LONG).show();
            }

        }

    }
}
