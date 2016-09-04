package com.example.environment;

import javax.swing.*;

/**
 * Created by Андрей on 04.09.2016.
 */
public class Environment {
    private JPanel panel1;
    private JSlider slider1;
    private JSlider slider2;


    public  static void main(String[] args) {
    JFrame frame = new JFrame("Environment");
    frame.setContentPane(new Environment().panel1);
  ///  frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    frame.pack();
    frame.setVisible(true);
}
}
