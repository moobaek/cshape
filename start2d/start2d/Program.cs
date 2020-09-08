using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

/*namespace MySystem.MySubSystem
{
    public class Class1
    {
        public int Calculate(int a, int b)
        {
            int abs_Sum = System.Math.Abs(a) + Math.Abs(b);
            return abs_Sum;
        }
    }
}*/
//새롭게 서브시스템을 만드는 namespace방식 
//대부분 클레스들이 네임스페이스 안에서 정의되며 이를 사용할땐 using System 을 다시 선언해줘야한다.

namespace start2d
{
    /* public class MyList
     {
         private int[] data = { 1, 2, 3, 4, 5 };

         public IEnumerator GetEnumerator()
         {
             int i = 0;
             while(i<data.Length)
             {
                 yield return data[i];
                 i++;
             }
         }

     }*/

    class Program
    {
        /*struct MyPoint
        {
            public int X;
            public int Y;

            public MyPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;

            }
            public override string ToString()
            {
                return string.Format("({0},{1})", X, Y);
            }

        }*/

        /*public class MyCustomer
        {
            private string name;
            private int age;
            //필드 선언임.

            public event EventHandler NameChaged;

            public MyCustomer()
            {
                name = string.Empty;
                age = -1;

            }
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        if (NameChaged != null)
                        {
                            NameChaged(this, EventArgs.Empty);
                        }
                    }
                }
            }
            
            public int Age
            {
                get { return this.age; }
                set { this.age = value; }
            }
            public string GetCustomerData()
            {
                string data = string.Format("Name: {0} (Age:{1})", this.Name, this.Age);
                return data;
            }*/
        //여기부분 여럽다..











        /*static IEnumerable<int> GetNumber()
        {
            yield return 10;
            yield return 20;
            yield return 30;
        }*/

        /*static IEnumerable<int> GetNumber()
        {
            yield return 10;
            yield return 20;
            yield return 10;
            yield return 20;
            yield return 10;
            yield return 20;

        }*/
        // yueld 은 순서대로 값을 리턴해주는 방법이다. 결국 이건 배열이며 호출할때 순서가 약속된 방식이라고 보면된다.
        //아마 함수의 간결함과 명확성때문에 사용하는듯?

        /*double _Sum = 0;
        DateTime _Time;
        bool? _Selected;

        public void CheckInput(int? i, double? d, DateTime? time, bool? selected)
        {
            if (i.HasValue && d.HasValue)
                this._Sum = (double)i.Value + (double)d.Value;

           
            if (!time.HasValue)
                throw new ArgumentException();
            else
                this._Time = time.Value;

            this._Selected = selected ?? false;
        }*/
        /*void NullableTest()
         {
             int? a = null;
             int? b = 0;
             int result = Nullable.Compare<int>(a, b);
             Console.WriteLine(result);

             double? c = 0.01;
             double? d = 0.0100;
             bool result2 = Nullable.Equals<double>(c, d);
             Console.WriteLine(result2);
         }*/

        //아마 Null허용여부를 넣는거같다. database에서 사용시 

        /*private void Calculate(int a)
        {
            a *= 2;
            
        }*/


        /*static double GetData(ref int a, ref double b)
        { return ++a * ++b; }

        static bool GetData(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a - b;
            return true;
        }*/
        //반환값이 다르면 같은 이름을 공유하였다고해도 다르게 사용될 수 있다. 들어가는 입력도 달라지고 받아주는 형식도 다르기때문.

        /*int Calc(int a, int b, string calcType="+")
        {
            switch(calcType)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    
                        return a / b;
                    
                default:
                    throw new ArithmeticException();
            }
                
            

        }*/
        
        static void Main(string[] args)
            {


            /* foreach(int num in GetNumber())
             {
                 Console.WriteLine(num);
             }*/

            /*var list = new MyList();
            foreach (var item in list)

            {
                Console.WriteLine(item);
            }

            IEnumerator it = list.GetEnmerator();
            it.MoveNext();
            Console.WriteLine(it.Current);
            it.MoveNext();
            Console.WriteLine(it.Current);
            */
            /*
                        try
                        {
                            Console.WriteLine("안녕세상아");
                        }

                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("오류난 세상아");
                        }
                        finally

                        {
                            Console.WriteLine("두개 끝나고 무조건 실행되더라.");
                        }
              */
            /*try
                    {
                        step1();
                        step2();
                        step3();

                    }
                    catch(IndexOutOfRangeException ex)
                    {
                        thow new MyException("Invalid index", ex);
                    }
                    catch(FileNotFoundException ex)
                    {
                        bool success = Log(ex);
                        if (!success)
                        {
                            throw ex;
                        }
                    }
                    catch(Exception ex)
                    {
                        Log(ex);
                        throw;
                    }*/
            /*string connStr = "Data Source=(local);Integrated Security=true;";
            string sql = "SELECT COUNT(1) FROM sys.objects";
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object count = cmd.ExecuteScalar();
                Console.WriteLine(count);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null &&
                    conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }*/
            //이부분 잘 모르겠음...솔직히...그냥 파일 열고 내부 까고 어떤 형태인지 받고...예외처리하고 
            //마지막에 안에 들어있고 상태가 열려있으면 닫는다?

            /* MyPoint pt = new MyPoint(10, 12);
             Console.WriteLine(pt.ToString());*/
            //결국 구조체를 끌어오는데 값+함수들 함수 리턴에 함수를 가져올 수 있다. 
            /*Program p = new Program();

            int val = 100;
            p.Calculate(val);
            */
            /* int x = 1;
             double y = 1.0;
             double ret = GetData(ref x, ref y);

             // out 사용. 초기화 불필요.
             int c, d;
             bool bret = GetData(10, 20, out c, out d);
         */
            /*Program p = new Program();
            int ret = p.Calc(1, 2);
            ret = p.Calc(1, 2, "*");
            */


            }
        }
    }

