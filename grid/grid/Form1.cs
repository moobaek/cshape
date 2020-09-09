using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            new MySqlConnection("Server=127.0.0.1;Port=3306;Database=board;Uid=root;Pwd=root;allow user variables=true");
        public static string constring1 = @"Data Source=127.0.0.1;Initial Catalog=board;Persist Security Info=True;User ID=root;Password=root;allow user variables=true";

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
            string query = $"INSERT INTO post(mnum, word, fword,title, id, time) VALUES ( 'one', 'two', 'three','four','five', getdate() )";

            //여기서는 삽입 쿼리문을 넣으면 될듯 (앞에 명령은 그대로 뒤에 값을 바꿔주면됨. 삽입값음. 일단은 빈칸에 넣고 

            ConnectDB();


            //그리드에 뿌려주면됨.


            CloseDB();
        }

        private void button2_Click(object sender, EventArgs e) //수정 UPDATE member_table SET user_name='김철수' WHERE user_id = 'test_id'

        {
            string query = $"INSERT INTO post(mnum, word, fword,title, id, time) VALUES('{label2.Text}','{textBox1.Text}',{label1.Text})";
            //
            ConnectDB();



            CloseDB();
        }

        private void button3_Click(object sender, EventArgs e)    //삭제 DELETE FROM member_table WHERE user_id='test_id'
        {
            ConnectDB();



            CloseDB();
        }

        private void button4_Click(object sender, EventArgs e)//조회 SELECT user_id, user_name, FROM member_table
        {
            ConnectDB();



            CloseDB();
        }
    }
}
