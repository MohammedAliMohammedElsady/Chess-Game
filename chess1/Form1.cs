using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace cafe_chess1
{
    public partial class Form1 : Form
    {
        public int x;
        public int flag;
        public int Start;
        public int ch;
        public int Button_kesh;
        public int number_of_moves = 1;
        public static int postion;
        public int[] arr = new int[64];
        public int[] LIGHT = new int[64];
        public int l = 0;
        public int varr1;
        public int varr2;
        public string ss;
        public int Mahamed = 0;
        public int[] kesh = new int[64];
        bool ex = false;
        int[] arr2 = new int[3]; // for king // عشان التبيت
        public int[] check = new int[65];
        public int CHESS = 0;
        public int BUTTON;
        public static Button[] my_button1 = new Button[65];
        public Pawn p1 = new Pawn();
        public Knight p2 = new Knight();
        public Bishop p3 = new Bishop();
        public Rook p4 = new Rook();
        public Queen p5 = new Queen();
        public King p6 = new King();
        public void GAME(int button)
        {
            if (Start == 0)
                return;
            if (CHESS == 0 && my_button1[button].BackgroundImage != null)
            {
                CHESS = 1;
                l = 0;
                flag = 0;
                BUTTON = button;
                if (ex)
                {
                    if (chessGame.c[button] == "King")
                    {
                        x = p6.all_possible_move(button, LIGHT);
                        light(LIGHT, x);
                    }
                    else
                    {
                        x = p6.posible_move_when_kesh_king(button, LIGHT, Button_kesh, ch, kesh);
                        light(LIGHT, x);
                    }
                }
                else
                {
                    if (chessGame.c[button] == "Pawn")
                    {
                        x = p1.all_possible_move(button, arr);
                        l = 0;
                        varr1 = chessGame.indxed[button];
                        chessGame.indxed[button] = 0;
                        chessGame.c[button] = null;
                        for (int cc = 0; cc < x; cc++)
                        {
                            ss = chessGame.c[arr[cc]];
                            varr2 = chessGame.indxed[arr[cc]];
                            chessGame.indxed[arr[cc]] = varr1;
                            chessGame.c[arr[cc]] = "Pawn";
                            if (p6.test_before_move(arr[cc]) == true)
                            {
                                LIGHT[l] = arr[cc];
                                l++;
                            }
                            chessGame.c[arr[cc]] = ss;
                            chessGame.indxed[arr[cc]] = varr2;
                        }
                        chessGame.indxed[button] = varr1;
                        chessGame.c[button] = "Pawn";
                        light(LIGHT, l);
                    }
                    else if (chessGame.c[button] == "Knight")
                    {
                        x = p2.all_possible_move(button, arr);
                        l = 0;
                        varr1 = chessGame.indxed[button];
                        chessGame.indxed[button] = 0;
                        chessGame.c[button] = null;
                        for (int cc = 0; cc < x; cc++)
                        {
                            ss = chessGame.c[arr[cc]];
                            varr2 = chessGame.indxed[arr[cc]];
                            chessGame.indxed[arr[cc]] = varr1;
                            chessGame.c[arr[cc]] = "Knight";
                            if (p6.test_before_move(arr[cc]) == true)
                            {
                                LIGHT[l] = arr[cc];
                                l++;
                            }
                            chessGame.c[arr[cc]] = ss;
                            chessGame.indxed[arr[cc]] = varr2;
                        }
                        chessGame.indxed[button] = varr1;
                        chessGame.c[button] = "Knight";
                        light(LIGHT, l);
                    }
                    else if (chessGame.c[button] == "Bishop")
                    {
                        x = p3.all_possible_move(button, arr);
                        l = 0;
                        varr1 = chessGame.indxed[button];
                        chessGame.indxed[button] = 0;
                        chessGame.c[button] = null;
                        for (int cc = 0; cc < x; cc++)
                        {
                            ss = chessGame.c[arr[cc]];
                            varr2 = chessGame.indxed[arr[cc]];
                            chessGame.indxed[arr[cc]] = varr1;
                            chessGame.c[arr[cc]] = "Bishop";
                            if (p6.test_before_move(arr[cc]) == true)
                            {
                                LIGHT[l] = arr[cc];
                                l++;
                            }
                            chessGame.c[arr[cc]] = ss;
                            chessGame.indxed[arr[cc]] = varr2;
                        }
                        chessGame.indxed[button] = varr1;
                        chessGame.c[button] = "Bishop";
                        light(LIGHT, l);
                    }
                    else if (chessGame.c[button] == "Rook")
                    {
                        x = p4.all_possible_move(button, arr);
                        l = 0;
                        varr1 = chessGame.indxed[button];
                        chessGame.indxed[button] = 0;
                        chessGame.c[button] = null;
                        for (int cc = 0; cc < x; cc++)
                        {
                            ss = chessGame.c[arr[cc]];
                            varr2 = chessGame.indxed[arr[cc]];
                            chessGame.indxed[arr[cc]] = varr1;
                            chessGame.c[arr[cc]] = "Rook";
                            if (p6.test_before_move(arr[cc]) == true)
                            {
                                LIGHT[l] = arr[cc];
                                l++;
                            }
                            chessGame.c[arr[cc]] = ss;
                            chessGame.indxed[arr[cc]] = varr2;
                        }
                        chessGame.indxed[button] = varr1;
                        chessGame.c[button] = "Rook";
                        light(LIGHT, l);
                    }
                    else if (chessGame.c[button] == "Queen")
                    {
                        x = p5.all_possible_move(button, arr);
                        l = 0;
                        varr1 = chessGame.indxed[button];
                        chessGame.indxed[button] = 0;
                        chessGame.c[button] = null;
                        for (int cc = 0; cc < x; cc++)
                        {
                            ss = chessGame.c[arr[cc]];
                            varr2 = chessGame.indxed[arr[cc]];
                            chessGame.indxed[arr[cc]] = varr1;
                            chessGame.c[arr[cc]] = "Queen";
                            if (p6.test_before_move(arr[cc]) == true)
                            {
                                LIGHT[l] = arr[cc];
                                l++;
                            }
                            chessGame.c[arr[cc]] = ss;
                            chessGame.indxed[arr[cc]] = varr2;
                        }
                        chessGame.indxed[button] = varr1;
                        chessGame.c[button] = "Queen";
                        light(LIGHT, l);
                    }
                    else if (chessGame.c[button] == "King")
                    {
                        x = p6.all_possible_move(button, arr);
                        if (p6.Special_Move(button, arr2) == true)
                        {
                            arr[x] = arr2[0];
                            x++;
                            if (arr2[1] != 0)
                            {
                                arr[x] = arr2[1];
                                x++;
                                flag++;
                            }
                            flag++;
                        }
                        for (int i = 0; i < x; i++)
                            LIGHT[i] = arr[i];
                        light(LIGHT, x);
                    }
                }
            }
            else if (CHESS == 1 && (my_button1[button] == null || my_button1[button] != my_button1[BUTTON]))
            {
                if (chessGame.c[BUTTON] == "Pawn")
                {
                    if (p1.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        postion = button; // for convert to any piece
                        p1.convert(button);
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                else if (chessGame.c[BUTTON] == "Knight")
                {
                    if (p2.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                else if (chessGame.c[BUTTON] == "Bishop")
                {
                    if (p3.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                else if (chessGame.c[BUTTON] == "Rook")
                {
                    if (p4.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                else if (chessGame.c[BUTTON] == "Queen")
                {
                    if (p5.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                else if (chessGame.c[BUTTON] == "King")
                {
                    if (p6.move_OR_kill(BUTTON, button, x, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        // السطور دي كلها عشان التحصين او التبيت
                        if ((arr2[0] == button || arr2[1] == button) && (King.king1 == 1 || King.king2 == 1))
                        {
                            if (button == 7 || button == 63)
                            {
                                my_button1[BUTTON + 1].BackgroundImage = my_button1[BUTTON + 3].BackgroundImage;
                                my_button1[BUTTON + 3].BackgroundImage = null;
                                chessGame.c[BUTTON + 3] = null;
                                chessGame.c[BUTTON + 1] = "Rook";
                                chessGame.indxed[BUTTON + 3] = 0;
                                if (BUTTON == 5)
                                    chessGame.indxed[BUTTON + 1] = 2;
                                else
                                    chessGame.indxed[BUTTON + 1] = 1;
                            }
                            else
                            {
                                my_button1[BUTTON - 1].BackgroundImage = my_button1[BUTTON - 4].BackgroundImage;
                                my_button1[BUTTON - 4].BackgroundImage = null;
                                chessGame.c[BUTTON - 4] = null;
                                chessGame.c[BUTTON - 1] = "Rook";
                                chessGame.indxed[BUTTON - 4] = 0;
                                if (BUTTON == 5)
                                    chessGame.indxed[BUTTON - 1] = 2;
                                else
                                    chessGame.indxed[BUTTON - 1] = 1;
                            }
                        }
                        ex = false;
                    }
                    Come_Back_Color(LIGHT, x);
                }
                if (p6.Draw_game(chessGame.indxed[button]) == true)
                        MessageBox.Show("Draw Game"); // ياريت نحسن يعني لو في حاجه احسن من الرسائل ياريت نعملها
                if (p6.check_for_end_game(button))
                {
                    MessageBox.Show("End Game!!!");
                    MessageBox.Show("the player  " + chessGame.indxed[button] + " is win");
                    Application.Restart();
                }
                if (ex == false)
                {
                    ch = p6.kesh_king(button, kesh);
                    if (ch != 0)
                    {
                        MessageBox.Show("kesh"); //ياريت نحط موسيقي او صوت عالي شوية لما الملك يبقي في وضع الكش ونشيل الرساله دي عشان عيب
                        ex = true;
                        Button_kesh = button;
                    }
                }
                BUTTON = button;
                CHESS = 0;
            }
            else if (CHESS == 1)
            {
                Come_Back_Color(LIGHT, x);
                BUTTON = button;
                CHESS = 0;
            }
        }
        public void Function_Button()
        {
            my_button1[1] = button1;
            my_button1[2] = button2;
            my_button1[3] = button3;
            my_button1[4] = button4;
            my_button1[5] = button5;
            my_button1[6] = button6;
            my_button1[7] = button7;
            my_button1[8] = button8;
            my_button1[9] = button9;
            my_button1[10] = button10;
            my_button1[11] = button11;
            my_button1[12] = button12;
            my_button1[13] = button13;
            my_button1[14] = button14;
            my_button1[15] = button15;
            my_button1[16] = button16;
            my_button1[17] = button17;
            my_button1[18] = button18;
            my_button1[19] = button19;
            my_button1[20] = button20;
            my_button1[21] = button21;
            my_button1[22] = button22;
            my_button1[23] = button23;
            my_button1[24] = button24;
            my_button1[25] = button25;
            my_button1[26] = button26;
            my_button1[27] = button27;
            my_button1[28] = button28;
            my_button1[29] = button29;
            my_button1[30] = button30;
            my_button1[31] = button31;
            my_button1[32] = button32;
            my_button1[33] = button33;
            my_button1[34] = button34;
            my_button1[35] = button35;
            my_button1[36] = button36;
            my_button1[37] = button37;
            my_button1[38] = button38;
            my_button1[39] = button39;
            my_button1[40] = button40;
            my_button1[41] = button41;
            my_button1[42] = button42;
            my_button1[43] = button43;
            my_button1[44] = button44;
            my_button1[45] = button45;
            my_button1[46] = button46;
            my_button1[47] = button47;
            my_button1[48] = button48;
            my_button1[49] = button49;
            my_button1[50] = button50;
            my_button1[51] = button51;
            my_button1[52] = button52;
            my_button1[53] = button53;
            my_button1[54] = button54;
            my_button1[55] = button55;
            my_button1[56] = button56;
            my_button1[57] = button57;
            my_button1[58] = button58;
            my_button1[59] = button59;
            my_button1[60] = button60;
            my_button1[61] = button61;
            my_button1[62] = button62;
            my_button1[63] = button63;
            my_button1[64] = button64;
        }
        public void Set(int[] arr)//Set, Set Check Back peieces Color White,Color Black.
        {
            int j = 1, counter = 1;
            for (int i = 1; i <= 64; i++)
            {
                if (counter + 8 == i)
                {
                    counter += 8;
                    j++;
                }
                arr[i] = j;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Function_Button();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 64; i++)
            {
                if (Mahamed == 0)
                {
                    if (i % 2 == 1)
                        my_button1[i].BackColor = Color.Peru;
                    else
                        my_button1[i].BackColor = Color.SaddleBrown;
                }
                else if (Mahamed == 1)
                {
                    if (i % 2 == 1)
                        my_button1[i].BackColor = Color.SaddleBrown;
                    else
                        my_button1[i].BackColor = Color.Peru;
                }
                if (i % 8 == 0 && Mahamed==0)
                    Mahamed = 1;
                else if (i % 8 == 0 && Mahamed == 1)
                    Mahamed = 0;
            }
        }
        public void light(int[] arr1, int size)
        {
            for (int i = 0; i < size; i++)
            {
                // if & else if ----> عشان مربع تحصين الملك يلون بلون مختلف عن الطبيعي لانها حركة خاصة للملك
                if (flag == 1 && i == size - 1)
                    my_button1[arr1[i]].BackColor = Color.Gold;
                else if (flag == 2 && (i == size - 1 || i == size - 2))
                    my_button1[arr1[i]].BackColor = Color.Gold;
                else
                    my_button1[arr1[i]].BackColor = Color.Orange;
            }
        }
        public void Come_Back_Color(int[] arr1, int size)         //Function Set Work back Color peieces.
        {
            Set(check);                             // CaLL Function Set array of int check.
            for (int i = 0; i < size; i++)
            {
                if (check[arr1[i]] % 2 == 0)     //if check[arr1[i]] is even ,if arr1[i] is even Color_Back,else arr1[i] is odd Color_White : else check[arr1[i]] is odd ,if arr1[i] is even Color_White,else Color_black
                {
                    if (arr1[i] % 2 == 0)
                        my_button1[arr1[i]].BackColor = Color.Peru;
                    else
                        my_button1[arr1[i]].BackColor = Color.SaddleBrown;
                }
                else
                {
                    if (arr1[i] % 2 != 0)
                        my_button1[arr1[i]].BackColor = Color.Peru;
                    else
                        my_button1[arr1[i]].BackColor = Color.SaddleBrown;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[1] == 1 || CHESS == 1))
                GAME(1);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[1] == 2 || CHESS == 1))
                GAME(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[2] == 1 || CHESS == 1))
                GAME(2);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[2] == 2 || CHESS == 1))
                GAME(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[3] == 1 || CHESS == 1))
                GAME(3);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[3] == 2 || CHESS == 1))
                GAME(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[4] == 1 || CHESS == 1))
                GAME(4);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[4] == 2 || CHESS == 1))
                GAME(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[5] == 1 || CHESS == 1))
                GAME(5);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[5] == 2 || CHESS == 1))
                GAME(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[6] == 1 || CHESS == 1))
                GAME(6);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[6] == 2 || CHESS == 1))
                GAME(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[7] == 1 || CHESS == 1))
                GAME(7);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[7] == 2 || CHESS == 1))
                GAME(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[8] == 1 || CHESS == 1))
                GAME(8);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[8] == 2 || CHESS == 1))
                GAME(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[9] == 1 || CHESS == 1))
                GAME(9);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[9] == 2 || CHESS == 1))
                GAME(9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[10] == 1 || CHESS == 1))
                GAME(10);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[10] == 2 || CHESS == 1))
                GAME(10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[11] == 1 || CHESS == 1))
                GAME(11);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[11] == 2 || CHESS == 1))
                GAME(11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[12] == 1 || CHESS == 1))
                GAME(12);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[12] == 2 || CHESS == 1))
                GAME(12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[13] == 1 || CHESS == 1))
                GAME(13);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[13] == 2 || CHESS == 1))
                GAME(13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[14] == 1 || CHESS == 1))
                GAME(14);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[14] == 2 || CHESS == 1))
                GAME(14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[15] == 1 || CHESS == 1))
                GAME(15);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[15] == 2 || CHESS == 1))
                GAME(15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[16] == 1 || CHESS == 1))
                GAME(16);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[16] == 2 || CHESS == 1))
                GAME(16);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[17] == 1 || CHESS == 1))
                GAME(17);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[17] == 2 || CHESS == 1))
                GAME(17);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[18] == 1 || CHESS == 1))
                GAME(18);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[18] == 2 || CHESS == 1))
                GAME(18);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[19] == 1 || CHESS == 1))
                GAME(19);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[19] == 2 || CHESS == 1))
                GAME(19);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[20] == 1 || CHESS == 1))
                GAME(20);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[20] == 2 || CHESS == 1))
                GAME(20);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[21] == 1 || CHESS == 1))
                GAME(21);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[21] == 2 || CHESS == 1))
                GAME(21);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[22] == 1 || CHESS == 1))
                GAME(22);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[22] == 2 || CHESS == 1))
                GAME(22);
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[23] == 1 || CHESS == 1))
                GAME(23);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[23] == 2 || CHESS == 1))
                GAME(23);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[24] == 1 || CHESS == 1))
                GAME(24);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[24] == 2 || CHESS == 1))
                GAME(24);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[25] == 1 || CHESS == 1))
                GAME(25);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[25] == 2 || CHESS == 1))
                GAME(25);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[26] == 1 || CHESS == 1))
                GAME(26);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[26] == 2 || CHESS == 1))
                GAME(26);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[27] == 1 || CHESS == 1))
                GAME(27);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[27] == 2 || CHESS == 1))
                GAME(27);
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[28] == 1 || CHESS == 1))
                GAME(28);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[28] == 2 || CHESS == 1))
                GAME(28);
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[29] == 1 || CHESS == 1))
                GAME(29);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[29] == 2 || CHESS == 1))
                GAME(29);
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[30] == 1 || CHESS == 1))
                GAME(30);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[30] == 2 || CHESS == 1))
                GAME(30);
        }
        private void button31_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[31] == 1 || CHESS == 1))
                GAME(31);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[31] == 2 || CHESS == 1))
                GAME(31);
        }
        private void button32_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[32] == 1 || CHESS == 1))
                GAME(32);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[32] == 2 || CHESS == 1))
                GAME(32);
        }
        private void button33_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[33] == 1 || CHESS == 1))
                GAME(33);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[33] == 2 || CHESS == 1))
                GAME(33);
        }
        private void button34_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[34] == 1 || CHESS == 1))
                GAME(34);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[34] == 2 || CHESS == 1))
                GAME(34);
        }
        private void button35_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[35] == 1 || CHESS == 1))
                GAME(35);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[35] == 2 || CHESS == 1))
                GAME(35);
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[36] == 1 || CHESS == 1))
                GAME(36);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[36] == 2 || CHESS == 1))
                GAME(36);
        }
        private void button37_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[37] == 1 || CHESS == 1))
                GAME(37);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[37] == 2 || CHESS == 1))
                GAME(37);
        }
        private void button38_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[38] == 1 || CHESS == 1))
                GAME(38);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[38] == 2 || CHESS == 1))
                GAME(38);
        }
        private void button39_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[39] == 1 || CHESS == 1))
                GAME(39);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[39] == 2 || CHESS == 1))
                GAME(39);
        }
        private void button40_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[40] == 1 || CHESS == 1))
                GAME(40);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[40] == 2 || CHESS == 1))
                GAME(40);
        }
        private void button41_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[41] == 1 || CHESS == 1))
                GAME(41);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[41] == 2 || CHESS == 1))
                GAME(41);
        }
        private void button42_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[42] == 1 || CHESS == 1))
                GAME(42);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[42] == 2 || CHESS == 1))
                GAME(42);
        }
        private void button43_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[43] == 1 || CHESS == 1))
                GAME(43);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[43] == 2 || CHESS == 1))
                GAME(43);
        }
        private void button44_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[44] == 1 || CHESS == 1))
                GAME(44);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[44] == 2 || CHESS == 1))
                GAME(44);
        }
        private void button45_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[45] == 1 || CHESS == 1))
                GAME(45);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[45] == 2 || CHESS == 1))
                GAME(45);
        }
        private void button46_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[46] == 1 || CHESS == 1))
                GAME(46);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[46] == 2 || CHESS == 1))
                GAME(46);
        }
        private void button47_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[47] == 1 || CHESS == 1))
                GAME(47);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[47] == 2 || CHESS == 1))
                GAME(47);
        }
        private void button48_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[48] == 1 || CHESS == 1))
                GAME(48);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[48] == 2 || CHESS == 1))
                GAME(48);
        }
        private void button49_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[49] == 1 || CHESS == 1))
                GAME(49);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[49] == 2 || CHESS == 1))
                GAME(49);
        }
        private void button50_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[50] == 1 || CHESS == 1))
                GAME(50);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[50] == 2 || CHESS == 1))
                GAME(50);
        }
        private void button51_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[51] == 1 || CHESS == 1))
                GAME(51);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[51] == 2 || CHESS == 1))
                GAME(51);
        }
        private void button52_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[52] == 1 || CHESS == 1))
                GAME(52);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[52] == 2 || CHESS == 1))
                GAME(52);
        }
        private void button53_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[53] == 1 || CHESS == 1))
                GAME(53);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[53] == 2 || CHESS == 1))
                GAME(53);
        }
        private void button54_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[54] == 1 || CHESS == 1))
                GAME(54);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[54] == 2 || CHESS == 1))
                GAME(54);
        }
        private void button55_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[55] == 1 || CHESS == 1))
                GAME(55);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[55] == 2 || CHESS == 1))
                GAME(55);
        }
        private void button56_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[56] == 1 || CHESS == 1))
                GAME(56);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[56] == 2 || CHESS == 1))
                GAME(56);
        }
        private void button57_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[57] == 1 || CHESS == 1))
                GAME(57);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[57] == 2 || CHESS == 1))
                GAME(57);
        }
        private void button58_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[58] == 1 || CHESS == 1))
                GAME(58);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[58] == 2 || CHESS == 1))
                GAME(58);
        }
        private void button59_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[59] == 1 || CHESS == 1))
                GAME(59);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[59] == 2 || CHESS == 1))
                GAME(59);
        }
        private void button60_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[60] == 1 || CHESS == 1))
                GAME(60);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[60] == 2 || CHESS == 1))
                GAME(60);
        }
        private void button61_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[61] == 1 || CHESS == 1))
                GAME(61);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[61] == 2 || CHESS == 1))
                GAME(61);
        }
        private void button62_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[62] == 1 || CHESS == 1))
                GAME(62);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[62] == 2 || CHESS == 1))
                GAME(62);
        }
        private void button63_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[63] == 1 || CHESS == 1))
                GAME(63);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[63] == 2 || CHESS == 1))
                GAME(63);
        }
        private void button64_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[64] == 1 || CHESS == 1))
                GAME(64);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[64] == 2 || CHESS == 1))
                GAME(64);
        }
        private void button65_Click(object sender, EventArgs e)
        {
            if (Start == 0)
            {
                Start = 1;
                MessageBox.Show("Let's play");
            }
        }
        private void button66_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void button67_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}