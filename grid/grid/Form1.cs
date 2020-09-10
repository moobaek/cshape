using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace grid
{

    public partial class Form1 : Form
    {


        


        MySqlConnection connection =
            new MySqlConnection("Server=127.0.0.1;Port=3306;Database=board;Uid=root;Pwd=root;allow user variables=true;CharSet=utf8;");
        public static string constring1 = @"Data Source=127.0.0.1;Initial Catalog=board;Persist Security Info=True;User ID=root;Password=root;allow user variables=true;CharSet=utf8;";

        MySqlConnection conn = new MySqlConnection();
        private string sConnString = "";
    
        public void ConnectDB()
        {
            try
            {
                sConnString = constring1;
            }
            catch
            {

            }
            if (conn.State.ToString().Equals("CLosed"))
            {
                conn.ConnectionString = sConnString;
                conn.Open();
            }


        }

        public void CloseDB()
        {

            if (conn != null)
            {
                conn.Close();
            }
        }

      public DataTable GetDataTable(string sql)

        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable ds = GetData();

            dataGridView1.DataSource = ds;
            CloseDB();
            //string query = $"INSERT INTO post(mnum, word, fword,title, id, time) VALUES('{label2.Text}','{textBox1.Text}',{label1.Text})";
            //이쪽 쿼리문은 데이터 베이스에서 데이터를 가져오는 항목입니다.

            //MySqlCommand command = new MySqlCommand(query, connection);
            //이쪽에서는 가져온 데이터를 grid에 뿌리는겁니다.

        }
        private DataTable GetData()
        {
            ConnectDB();
            //SqlConnection conn = new SqlConnection(strConn); //connection.ConnectionString
            //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Scores", connection.ConnectionString);
            
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM post", sConnString);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseDB();
            return dt;

        }


        private void button1_Click(object sender, EventArgs e) ///추가 INSERT  user_id, user_password, user_name, user_regdate ) VALUES ( 'test_id', 'testpwd', '홍길동', getdate() )

        {

            this.Cursor = Cursors.WaitCursor;

            DataTable dtChanges = new DataTable();

            DataTable dtSTUDENT = (DataTable)dataGridView1.DataSource;

            dtChanges = dtSTUDENT.GetChanges(DataRowState.Modified);
            string mnum_m = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string fword_m = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string title_m = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string id_m = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string time_m = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            

            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

          

            string insert_query = $"INSERT INTO post(mnum, fword, title, id, time) VALUES('{mnum_m}','{fword_m}','{title_m}','{id_m}','{label3.Text}')";
            //MySqlCommand command = new MySqlCommand(query, connection);
            /*MySqlDataAdapter adapter = new MySqlDataAdapter(
                "INSERT INTO post(mnum, fword, title, id, time) VALUES('{mnum_m}','{fword_m }','{title_m}','{id_m}','{time_m}')"
                , sConnString);*/
            /////
            ///
            connection.Open();
            MySqlCommand command = new MySqlCommand(insert_query, connection);

            try//확인용
            {

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("작성완료");
                }
                else
                {
                    MessageBox.Show("오류가 발생하였습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            connection.Close();





            // MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

            DataTable ds = GetData();

            dataGridView1.DataSource = ds;
            




            //그리드에 뿌려주면됨.

            CloseDB();
        }

        private void button2_Click(object sender, EventArgs e) //수정 UPDATE member_table SET user_name='김철수'  WHERE mnum = '{mnum_d}'

        {


            //MySqlDataAdapter adapter = new MySqlDataAdapter("UPDATE board SET post = '"+mnum_m+"', '"+fword_m+ "','"+title_m+"','" + id_m + "','" + title_m+"'" , sConnString);




            this.Cursor = Cursors.WaitCursor;

            DataTable dtChanges = new DataTable();

            DataTable dtSTUDENT = (DataTable)dataGridView1.DataSource;

            dtChanges = dtSTUDENT.GetChanges(DataRowState.Modified);
            string mnum_m = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string fword_m = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string title_m = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string id_m = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string time_m = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



            string modi_query = $"UPDATE board.post SET fword='{fword_m}', title='{title_m}', time='{time_m}' WHERE mnum = '{mnum_m}'";
            //MySqlCommand command = new MySqlCommand(query, connection);
            /*MySqlDataAdapter adapter = new MySqlDataAdapter(
                "INSERT INTO post(mnum, fword, title, id, time) VALUES('{mnum_m}','{fword_m }','{title_m}','{id_m}','{time_m}')"
                , sConnString);*/
            /////
            ///
            connection.Open();
            MySqlCommand command = new MySqlCommand(modi_query, connection);

            try//확인용
            {

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("수정완료");
                }
                else
                {
                    MessageBox.Show("오류가 발생하였습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            connection.Close();





            // MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

            DataTable ds = GetData();

            dataGridView1.DataSource = ds;





            //그리드에 뿌려주면됨.

            CloseDB();
        }

        private void button3_Click(object sender, EventArgs e)    //삭제 DELETE FROM member_table WHERE user_id='test_id'
        {
            ConnectDB();
            this.Cursor = Cursors.WaitCursor;

            DataTable dtChanges = new DataTable();

            DataTable dtSTUDENT = (DataTable)dataGridView1.DataSource;

            dtChanges = dtSTUDENT.GetChanges(DataRowState.Modified);
            string mnum_d = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



            string del_query = $"DELETE FROM board.post WHERE mnum = '{mnum_d}'";
            //MySqlCommand command = new MySqlCommand(query, connection);
            /*MySqlDataAdapter adapter = new MySqlDataAdapter(
                "INSERT INTO post(mnum, fword, title, id, time) VALUES('{mnum_m}','{fword_m }','{title_m}','{id_m}','{time_m}')"
                , sConnString);*/
            /////
            ///
            connection.Open();
            MySqlCommand command = new MySqlCommand(del_query, connection);

            try//확인용
            {

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("삭제완료");
                }
                else
                {
                    MessageBox.Show("오류가 발생하였습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            connection.Close();





            // MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

            DataTable ds = GetData();

            dataGridView1.DataSource = ds;





            //그리드에 뿌려주면됨.

            CloseDB();


        }

        private void button4_Click(object sender, EventArgs e)//조회 SELECT user_id, user_name, FROM board.post
        {
            ConnectDB();
            this.Cursor = Cursors.WaitCursor;

            DataTable dtChanges = new DataTable();

            DataTable dtSTUDENT = (DataTable)dataGridView1.DataSource;

          

            dtChanges = dtSTUDENT.GetChanges(DataRowState.Modified);
            string mnum_m = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string fword_m = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string title_m = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string id_m = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string time_m = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



            string sel_query = $"SELECT * FROM board.post";
            //MySqlCommand command = new MySqlCommand(query, connection);
            /*MySqlDataAdapter adapter = new MySqlDataAdapter(
                "INSERT INTO post(mnum, fword, title, id, time) VALUES('{mnum_m}','{fword_m }','{title_m}','{id_m}','{time_m}')"
                , sConnString);*/
            /////
            ///
            connection.Open();

            DataTable ds = GetData();

            //dataGridView2.DataSource = ds;

            connection.Close();





            // MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, connection);

           

            //그리드에 뿌려주면됨.


            CloseDB();
        }
    }
}
