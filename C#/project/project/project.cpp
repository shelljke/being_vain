// project.cpp: ���������� ����� ����� ��� ����������� ����������.
//
#include "stdafx.h"
#include <iostream>
#include <vector>
#include<iterator>
#include <string>
#include <cstdio>
using namespace std;



int main()

{
	setlocale(LC_ALL, "Rus");

	string s;
	string ss; 

	cout << "������� ������: ";
	cin >> s;
	//������� �������
	{
		
		cout << "��������� ������: ";
		cout << ss;

		
		int len = s.length();
		vector<int> p(len);
		p[0] = 0; 

		int k = 0;
		for (int i = 1; i < len; i++) 
		{
			while ((k > 0) && (s[k] != s[i]))
				k = p[k - 1];
			if (s[k] == s[i])
				k++;
			p[i] = k;
			//cout << k;
		}
		k = 0;
		int o = 0;
		int u = 0;
		//���������� ����� ��������
		for (int i = 0; i < len - 1; i++)
		{
			if ((p[i + 1] >p[i]) && (p[i + 1]>k))
			{
				k = p[i + 1];
				u = i + 1;
			}
		}

		for (int i = 0; i < u; i++)
		{
			if (p[i]==0)
			{
				o++;
			}

		}

		int oo = 0;
		for (int i = 0; i < len; i++)
		{
			if (p[i] == 0)
			{
				oo++;
			}
			else break;
		}


		if (k > o)
			k = oo;

		//��������� � ��������� ������ ������� ��������, ������� ����� � ��������. ����� �������, ������� ������� ������
		string ss = s.substr(0, k);


		//������� ��������� ������
		cout << "��������� ������: ";
		cout << ss;
		int e = 0;
		//�������, ������� ��� ���������� �������, ��� � ���� ������� ����� k;
		//string sss;
		for (int i = 0; i < len; i++)
		{
			string	sss = s.substr(i,  k);
			if (sss == ss)
			{
				e++;
			}
		}
		cout <<"\n"<< "���������� ����������: " << e << "\n";
	}
	
	system("pause");
}

