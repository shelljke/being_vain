package com.example.environment;

import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;


public class Environment {
    private JPanel panel1;
    private JSlider slider1;
    private JLabel label;
    private JButton button1;


    public Environment() {

        button1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                label.setText("");
            }
        });
        slider1.addChangeListener(new ChangeListener() {
            @Override
            public void stateChanged(ChangeEvent e) {
                label.setText(String.valueOf(slider1.getValue()));
            }
        });
    }

    public  static void main(String[] args) {
    JFrame frame = new JFrame("Environment");
    frame.setContentPane(new Environment().panel1);
    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    frame.pack();
    frame.setVisible(true);
}
}
