using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace WindowsFormsApplication2
{





    public partial class Form1 : Form
    {
        //ConnectionString = "192.168.0.124;allow user variables=true";

        MySqlConnection connection =
        new MySqlConnection("Server=127.0.0.1;Port=3306;Database=for_test;Uid=root;Pwd=root;allow user variables=true");
        

        public Form1()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {


            Button btnTmp = (Button)sender;
            
            //42 43 45 47 사칙연산 코드
            if (
                btnTmp.Text.Equals("+") || 
                btnTmp.Text.Equals("-") || 
                btnTmp.Text.Equals("*") || 
                btnTmp.Text.Equals("/")
                )
            {


                if (textBox1.Text.Equals(""))
                {
                    textBox1.Text = "0";
                }
                if (textBox1.Text[textBox1.Text.Length - 1].Equals('+') ||
                    textBox1.Text[textBox1.Text.Length - 1].Equals('-') ||
                    textBox1.Text[textBox1.Text.Length - 1].Equals('*') ||
                    textBox1.Text[textBox1.Text.Length - 1].Equals('/'))
                {

                
                        //마지막 문자 삭제 후 집어넣기
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

                    //.Remove(txtResult.Text.Length - 1);
                    textBox1.Text += btnTmp.Text;

                }
                
                else
                    textBox1.Text += btnTmp.Text;

            }
            else
                textBox1.Text += btnTmp.Text;
        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            
            //DBMS: MARIA_DB
            //IP: 192.168.0.124
            //Port: 3306
            //Database Name: for_test
            //ID: root
            //PW: dbmes1!

            //목표
            //[계산식], [계산 결과]
            //        및[저장날짜] 저장 추가

            //테이블 생성 필요
           

            string[] plusSplit = textBox1.Text.Split('+');
            double result = 0;
          
            for (int i = 0; i < plusSplit.Length; i++)
            {
                string[] minusSplit = plusSplit[i].Split('-');
                double minusSplitResult = 0;

                for (int j = 0; j < minusSplit.Length; j++)
                {
                    string[] multiSplit = minusSplit[j].Split('*');
                    double multSplitResult = 0;

                    for (int k = 0; k < multiSplit.Length; k++)
                    {
                        string[] divSplit = multiSplit[k].Split('/');
                        double divSplitResult = 0;



                        for (int l = 0; l < divSplit.Length; l++)
                        {
                            if (l == 0)
                                divSplitResult += Convert.ToDouble(divSplit[l]);
                            else
                                divSplitResult /= Convert.ToDouble(divSplit[l]);
                        }
                        multiSplit[k] = Convert.ToString(divSplitResult);

                        if (k == 0)
                            multSplitResult += Convert.ToDouble(multiSplit[k]);
                        else
                            multSplitResult *= Convert.ToDouble(multiSplit[k]);
                        minusSplit[j] = Convert.ToString(multSplitResult);
                    }
                    minusSplit[j] = Convert.ToString(multSplitResult);

                    if (j == 0)
                        minusSplitResult += Convert.ToDouble(minusSplit[j]);
                    else
                        minusSplitResult -= Convert.ToDouble(minusSplit[j]);
                }
                    plusSplit[i] = Convert.ToString(minusSplitResult);


                    Console.WriteLine(plusSplit[i]);
                    result += Convert.ToDouble(plusSplit[i]);
                }

                label1.Text = Convert.ToString(result);
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //여기서부터 db 열거임

            //ConnectionString = "192.168.0.124;allow user variables=true";
            string query = $"INSERT INTO clc(date,exp,val) VALUES('{label2.Text}','{textBox1.Text}',{label1.Text})";
            //string insertQuery = "INSERT INTO clc(date,exp,val) VALUES('" + label2.Text + "','" + textBox1.Text + "'," + label1.Text + ")";




            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
          
            try//확인용
            {
                
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            connection.Close();



        }
        
        }

    
    }

