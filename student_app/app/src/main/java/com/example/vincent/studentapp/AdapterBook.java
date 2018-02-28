package com.example.vincent.studentapp;

import android.content.Context;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.Collections;
import java.util.List;

/**
 * Created by 0315310 on 2/7/2018.
 */

public class AdapterBook extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private Context context;
    private LayoutInflater inflater;
    List<DataBook> data= Collections.emptyList();
    DataBook current;
    int currentPos=0;

    // create constructor to innitilize context and data sent from MainActivity
    public AdapterBook(Context context, List<DataBook> data){
        this.context=context;
        inflater= LayoutInflater.from(context);
        this.data=data;
    }

    // Inflate the layout when viewholder created
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view=inflater.inflate(R.layout.container_library, parent,false);
        MyHolder holder=new MyHolder(view);
        return holder;
    }

    // Bind data
    @Override
    public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {

        // Get current position of item in recyclerview to bind data and assign values from list
        MyHolder myHolder= (MyHolder) holder;
        DataBook current=data.get(position);
        myHolder.textTitle.setText(current.Title);
        myHolder.textBookID.setText("BookID: " + current.BookID);
        myHolder.textAuthor.setText("Author: " + current.Author);
        myHolder.textCopies.setText("Qty. " + current.Copies);
        //myHolder.textPrice.setTextColor(ContextCompat.getColor(context, R.color.colorAccent));

        // load image into imageview using glide


    }

    // return total item from List
    @Override
    public int getItemCount() {
        return data.size();
    }


    class MyHolder extends RecyclerView.ViewHolder{

        TextView textTitle;
        TextView textBookID;
        TextView textAuthor;
        TextView textCopies;
        //TextView textPrice;

        // create constructor to get widget reference
        public MyHolder(View itemView) {
            super(itemView);
            textTitle= (TextView) itemView.findViewById(R.id.textTitle);
            textBookID= (TextView) itemView.findViewById(R.id.textBookID);
            textAuthor = (TextView) itemView.findViewById(R.id.textAuthor);
            textCopies = (TextView) itemView.findViewById(R.id.textCopies);
            //textPrice = (TextView) itemView.findViewById(R.id.textPrice);
        }

    }

}
