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
    public class chessGame
    {
        public static int button_number;
        public static string[] c;
        public static int[] indxed;
        public chessGame()
        {
            c = new string[65];
            indxed = new int[65];
            c[1] = c[8] = c[57] = c[64] = "Rook";
            c[2] = c[7] = c[58] = c[63] = "Knight";
            c[3] = c[6] = c[59] = c[62] = "Bishop";
            c[4] = c[60] = "Queen";
            c[5] = c[61] = "King";
            for (int i = 9; i <= 16; i++)
                c[i] = "Pawn";
            for (int i = 49; i <= 56; i++)
                c[i] = "Pawn";
            for (int i = 17; i <= 48; i++)
                c[i] = null;
            for (int i = 1; i <= 16; i++)
                indxed[i] = 2;
            for (int i = 49; i <= 64; i++)
                indxed[i] = 1;
            for (int i = 17; i <= 48; i++)
                indxed[i] = 0;
        }
    }
    public class Pawn : chessGame
    {
        public bool[] array_of_postion1;
        public bool[] array_of_postion;
        public Pawn()
        {
            array_of_postion = new bool[65];
            array_of_postion1 = new bool[65];
            for (int i = 9; i <= 16; i++)
                array_of_postion[i] = true;
            for (int i = 49; i <= 57; i++)
                array_of_postion1[i] = true;
        }
        public bool check_piece(int index)
        {
            if (c[index] == "Pawn")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                if (indxed[button_number] == 2)
                {
                    if (button_number + 8 <= 64 && c[button_number + 8] == null)
                    {
                        arr[i] = (button_number + 8);
                        i++;
                        if (button_number + 16 <= 64 && c[button_number + 16] == null && array_of_postion[button_number])
                        {
                            arr[i] = (button_number + 16); i++;
                        }

                    }
                    if (button_number + 9 <= 64 && c[button_number + 9] != null && button_number % 8 != 0 && indxed[button_number + 9] != 2)
                    {
                        arr[i] = (button_number + 9);
                        i++;
                    }
                    if (button_number + 7 <= 64 && c[button_number + 7] != null && (button_number - 1) % 8 != 0 && indxed[button_number + 7] != 2)
                    {
                        arr[i] = (button_number + 7);
                        i++;
                    }
                }
                else
                {
                    if (button_number - 8 >= 1 && c[button_number - 8] == null)
                    {
                        arr[i] = (button_number - 8);
                        i++;
                        if (button_number - 16 >= 1 && c[button_number - 16] == null && array_of_postion1[button_number])
                        {
                            arr[i] = (button_number - 16); i++;
                        }
                    }
                    if (button_number - 9 >= 1 && c[button_number - 9] != null && (button_number - 1) % 8 != 0 && indxed[button_number - 9] != 1)
                    {
                        arr[i] = (button_number - 9);
                        i++;
                    }
                    if (button_number - 7 >= 1 && c[button_number - 7] != null && button_number % 8 != 0 && indxed[button_number - 7] != 1)
                    {
                        arr[i] = (button_number - 7);
                        i++;
                    }
                }
            }
            return i;
        }
        public void convert(int button)
        {
            if (button >= 1 && button <= 8)
            {
                Form2 f = new Form2();
                f.Show();
            }
            else if (button >= 57 && button <= 64)
            {
                Form3 ff = new Form3();
                ff.Show();
            }
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class Knight : chessGame
    {
        public int[] arr;
        public Knight()
        {
            arr = new int[64];
        }
        public bool check_piece(int index)
        {
            if (c[index] == "Knight")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                // 8 postions maximum for knight
                int row1 = button_number / 8;
                if (button_number % 8 != 0)
                    row1++;
                if (button_number + 10 <= 64 && ((c[button_number + 10] == null) || (indxed[button_number + 10] != indxed[button_number])))
                {
                    int row2 = (button_number + 10) / 8;
                    if ((button_number + 10) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 10);
                        i++;
                    }
                }
                if (button_number + 6 <= 64 && ((c[button_number + 6] == null) || (indxed[button_number + 6] != indxed[button_number])))
                {
                    int row2 = (button_number + 6) / 8;
                    if ((button_number + 6) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 6);
                        i++;
                    }
                }
                if (button_number + 17 <= 64 && ((c[button_number + 17] == null) || (indxed[button_number + 17] != indxed[button_number])))
                {
                    int row2 = (button_number + 17) / 8;
                    if ((button_number + 17) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 17);
                        i++;
                    }
                }
                if (button_number + 15 <= 64 && ((c[button_number + 15] == null) || (indxed[button_number + 15] != indxed[button_number])))
                {
                    int row2 = (button_number + 15) / 8;
                    if ((button_number + 15) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 15);
                        i++;
                    }
                }
                if (button_number - 10 >= 1 && ((c[button_number - 10] == null) || (indxed[button_number - 10] != indxed[button_number])))
                {
                    int row2 = (button_number - 10) / 8;
                    if ((button_number - 10) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 10);
                        i++;
                    }
                }
                if (button_number - 6 >= 1 && ((c[button_number - 6] == null) || (indxed[button_number - 6] != indxed[button_number])))
                {
                    int row2 = (button_number - 6) / 8;
                    if ((button_number - 6) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 6);
                        i++;
                    }
                }
                if (button_number - 17 >= 1 && ((c[button_number - 17] == null) || (indxed[button_number - 17] != indxed[button_number])))
                {
                    int row2 = (button_number - 17) / 8;
                    if ((button_number - 17) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 17);
                        i++;
                    }
                }
                if (button_number - 15 >= 1 && ((c[button_number - 15] == null) || (indxed[button_number - 15] != indxed[button_number])))
                {
                    int row2 = (button_number - 15) / 8;
                    if ((button_number - 15) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 15);
                        i++;
                    }
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                // 8 postions maximum for knight
                int row1 = button_number / 8;
                if (button_number % 8 != 0)
                    row1++;
                if (button_number + 10 <= 64 && ((c[button_number + 10] == null) || (indxed[button_number + 10] == indxed[button_number])))
                {
                    int row2 = (button_number + 10) / 8;
                    if ((button_number + 10) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 10);
                        i++;
                    }
                }
                if (button_number + 6 <= 64 && ((c[button_number + 6] == null) || (indxed[button_number + 6] == indxed[button_number])))
                {
                    int row2 = (button_number + 6) / 8;
                    if ((button_number + 6) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 6);
                        i++;
                    }
                }
                if (button_number + 17 <= 64 && ((c[button_number + 17] == null) || (indxed[button_number + 17] == indxed[button_number])))
                {
                    int row2 = (button_number + 17) / 8;
                    if ((button_number + 17) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 17);
                        i++;
                    }
                }
                if (button_number + 15 <= 64 && ((c[button_number + 15] == null) || (indxed[button_number + 15] == indxed[button_number])))
                {
                    int row2 = (button_number + 15) / 8;
                    if ((button_number + 15) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 15);
                        i++;
                    }
                }
                if (button_number - 10 >= 1 && ((c[button_number - 10] == null) || (indxed[button_number - 10] == indxed[button_number])))
                {
                    int row2 = (button_number - 10) / 8;
                    if ((button_number - 10) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 10);
                        i++;
                    }
                }
                if (button_number - 6 >= 1 && ((c[button_number - 6] == null) || (indxed[button_number - 6] == indxed[button_number])))
                {
                    int row2 = (button_number - 6) / 8;
                    if ((button_number - 6) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 6);
                        i++;
                    }
                }
                if (button_number - 17 >= 1 && ((c[button_number - 17] == null) || (indxed[button_number - 17] == indxed[button_number])))
                {
                    int row2 = (button_number - 17) / 8;
                    if ((button_number - 17) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 17);
                        i++;
                    }
                }
                if (button_number - 15 >= 1 && ((c[button_number - 15] == null) || (indxed[button_number - 15] == indxed[button_number])))
                {
                    int row2 = (button_number - 15) / 8;
                    if ((button_number - 15) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 15);
                        i++;
                    }
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }

    }
    public class Bishop : chessGame
    {
        public int[] arr;
        public Bishop()
        {
            arr = new int[65];
        }
        public bool check_piece(int index)
        {
            if (c[index] == "Bishop" || c[index] == "Queen")
                return true;
            return false;
        }
        /*  public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            int team = 0;
            int but = button_number;
            if (check1(button_number))
            {
                while ((but + 9) % 8 != 0 && but + 9 <= 64 && (c[but + 9] == null || indxed[but + 9] != indxed[button_number]))
                {
                    int row1 = but / 8;
                    if (but % 8 != 0)
                        row1++;
                    int row2 = (but + 9) / 8;
                    if ((but + 9) % 8 != 0)
                        row2++;
                    if (row2 - row1 != 1)
                        break;
                    but += 9;
                    arr[i] = but;
                    i++;
                    if (c[but] != null)
                    {
                        team++;
                        break;
                    }
                }
                if ((but + 9) % 8 == 0 && but + 9 <= 64 &&team==0&& (c[but + 9] == null || indxed[but + 9] != indxed[button_number]))
                {
                    but += 9;
                    arr[i] = but;
                    i++;
                }
                but = button_number;
                team = 0;
                while ((but - 9) % 8 != 1 && but - 9 > 0 && (c[but - 9] == null || indxed[but - 9] != indxed[button_number]))
                {
                    int row1 = but / 8;
                    if (but % 8 != 0)
                        row1++;
                    int row2 = (but - 9) / 8;
                    if ((but - 9) % 8 != 0)
                        row2++;
                    if (row1 - row2 != 1)
                        break;
                    but -= 9;
                    arr[i] = but;
                    i++;
                    if (c[but] != null)
                    {
                        team++;
                        break;
                    }
                }
                if ((but - 9) % 8 == 1 && but - 9 > 0 &&team==0 && (c[but - 9] == null || indxed[but - 9] != indxed[button_number]))
                {
                    but -= 9;
                    arr[i] = but;
                    i++;
                }
                but = button_number;
                team = 0;
                while ((but + 7) % 8 != 1 && but + 7 <= 64 && (c[but + 7] == null || indxed[but + 7] != indxed[button_number]))
                {
                    int row1 = but / 8;
                    if (but % 8 != 0)
                        row1++;
                    int row2 = (but + 7) / 8;
                    if ((but + 7) % 8 != 0)
                        row2++;
                    if (row2 - row1 != 1)
                        break;
                    but += 7;
                    arr[i] = but;
                    i++;
                    if (c[but] != null)
                    {
                        team++;
                        break;
                    }
                }
                if ((but + 7) % 8 == 1 && but + 7 <= 64 && team == 0 && (c[but + 7] == null || indxed[but + 7] != indxed[button_number]))
                {
                    but += 7;
                    arr[i] = but;
                    i++;
                }
                but = button_number;
                team = 0;
                while ((but - 7) % 8 != 0 && but - 7 > 0 && (c[but - 7] == null || indxed[but - 7] != indxed[button_number]))
                {
                    int row1 = but / 8;
                    if (but % 8 != 0)
                        row1++;
                    int row2 = (but - 7) / 8;
                    if ((but - 7) % 8 != 0)
                        row2++;
                    if (row1 - row2 != 1)
                        break;
                    but -= 7;
                    arr[i] = but;
                    i++;
                    if (c[but] != null)
                    {
                        team++;
                        break;
                    }
                }
                if ((but - 7) % 8 == 0 && but - 7 > 0 && team == 0 &&(c[but - 7] == null || indxed[but - 7] != indxed[button_number]))
                {
                    but -= 7;
                    arr[i] = but;
                    i++;
                }
            }
            return i;
        }*/
        // Mahamed
        public int all_possible_move(int button_number, int[] arr) // Fouad
        {
            int i = 0;
            int x = button_number;
            if (check_piece(button_number))
            {
                while ((x + 9) % 8 != 1 && x + 9 <= 64 && (c[x + 9] == null || indxed[x + 9] != indxed[button_number]))
                {
                    arr[i] = x + 9;
                    i++;
                    if (c[x + 9] != null)
                        break;
                    x += 9;
                }
                x = button_number;
                while ((x - 9) % 8 != 0 && x - 9 > 0 && (c[x - 9] == null || indxed[x - 9] != indxed[button_number]))
                {
                    arr[i] = x - 9;
                    i++;
                    if (c[x - 9] != null)
                        break;
                    x -= 9;
                }

                x = button_number;
                while ((x + 7) % 8 != 0 && x + 7 <= 64 && (c[x + 7] == null || indxed[x + 7] != indxed[button_number]))
                {
                    arr[i] = x + 7;
                    i++;
                    if (c[x + 7] != null)
                        break;
                    x += 7;

                }
                x = button_number;
                while ((x - 7) % 8 != 1 && x - 7 > 0 && (c[x - 7] == null || indxed[x - 7] != indxed[button_number]))
                {
                    arr[i] = x - 7;
                    i++;
                    if (c[x - 7] != null)
                        break;
                    x -= 7;
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            int x = button_number;
            if (check_piece(button_number))
            {
                while ((x + 9) % 8 != 1 && x + 9 <= 64)
                {
                    arr[i] = x + 9;
                    i++;
                    if (c[x + 9] != null && c[x + 9] != "King")
                        break;
                    x += 9;
                }
                x = button_number;
                while ((x - 9) % 8 != 0 && x - 9 > 0 )
                {
                    arr[i] = x - 9;
                    i++;
                    if (c[x - 9] != null && c[x - 9] != "King")
                        break;
                    x -= 9;
                }
                x = button_number;
                while ((x + 7) % 8 != 0 && x + 7 <= 64 )
                {
                    arr[i] = x + 7;
                    i++;
                    if (c[x + 7] != null && c[x + 7] != "King")
                        break;
                    x += 7;
                }
                x = button_number;
                while ((x - 7) % 8 != 1 && x - 7 > 0 )
                {
                    arr[i] = x - 7;
                    i++;
                    if (c[x - 7] != null&&c[x-7]!="King")
                        break;
                    x -= 7;
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class Rook : chessGame
    {
        public int[] arr;
        public int k;
        public Rook()
        {
            arr = new int[65];
        }
        public bool check_piece(int index)
        {
            if (c[index] == "Rook" || c[index] == "Queen")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            int but = button_number;
            if (check_piece(button_number))
            {
                if (but % 8 != 0) // Move right
                {
                    while (but % 8 != 0)
                    {
                        but++;
                        if (c[but] == null || indxed[button_number] != indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (c[but] != null)
                            break;
                    }
                }
                but = button_number;
                if (but % 8 != 1) // Move left
                {
                    while (but % 8 != 1)
                    {
                        but--;
                        if (c[but] == null || indxed[button_number] != indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (c[but] != null)
                            break;
                    }
                }
                but = button_number;
                while (but + 8 <= 64) // move down 
                {
                    but += 8;
                    if (c[but] == null || indxed[button_number] != indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (c[but] != null)
                        break;
                }
                but = button_number;
                while (but - 8 >= 1) // move up
                {
                    but -= 8;
                    if (c[but] == null || indxed[button_number] != indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (c[but] != null)
                        break;
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            int but = button_number;
            if (check_piece(button_number))
            {
                if (but % 8 != 0) // Move right
                {
                    while (but % 8 != 0)
                    {
                        but++;
                        if (c[but] == null || indxed[button_number] == indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (c[but] != null)
                            break;
                    }
                }
                but = button_number;
                if (but % 8 != 1) // Move left
                {
                    while (but % 8 != 1)
                    {
                        but--;
                        if (c[but] == null || indxed[button_number] == indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (c[but] != null)
                            break;
                    }
                }
                but = button_number;
                while (but + 8 <= 64) // move down 
                {
                    but += 8;
                    if (c[but] == null || indxed[button_number] == indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (c[but] != null)
                        break;
                }
                but = button_number;
                while (but - 8 >= 1) // move up
                {
                    but -= 8;
                    if (c[but] == null || indxed[button_number] == indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (c[but] != null)
                        break;
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class Queen : chessGame
    {
        public int[] arr;
        public Queen()
        {
            arr = new int[65];
        }
        public bool check_piece(int index)
        {
            if (c[index] == "Queen")
                return true;
            return false;
        }
        Rook r = new Rook();
        Bishop b = new Bishop();
        public int all_possible_move(int button_number, int[] arr)
        {
            int[] arr2 = new int[64];
            int x = r.all_possible_move(button_number, arr2);
            for (int j = 0; j < x; j++)
                arr[j] = arr2[j];
            int i = x;
            x = b.all_possible_move(button_number, arr2);
            for (int j = 0; j < x; j++)
            {
                arr[i] = arr2[j];
                i++;
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int[] arr2 = new int[64];
            int x = r.all_possible_move_for_king(button_number, arr2);
            for (int j = 0; j < x; j++)
                arr[j] = arr2[j];
            int i = x;
            x = b.all_possible_move_for_king(button_number, arr2);
            for (int j = 0; j < x; j++)
            {
                arr[i] = arr2[j];
                i++;
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class King : chessGame
    {
        public int[] arr;
        public int[] enemy;
        public int[] friends;
        public int[] yy;
        public int[] xx;
        public int[] xxx;
        public int[] arr1;
        public static int king1;
        public static int king2;
        int w, w1, ccc;
        int var, variable, but;
        int button_numberx;
        string s;
        Pawn p1 = new Pawn();
        Bishop p2 = new Bishop();
        Knight p3 = new Knight();
        Rook p4 = new Rook();
        Queen p5 = new Queen();
        public King()
        {
            arr = new int[65];
            enemy = new int[65];
            friends = new int[65];
            yy = new int[65];
            xx = new int[65];
            xxx = new int[65];
            arr1 = new int[65];
        }
        public bool check_piece(int index)
        {
            if (c[index] == "King")
                return true;
            return false;
        }
        public void enemy_move(int button_number, int[] enemy, int a, int cc)
        {
            int[] arr = new int[64];
            int x;
            for (int i = 1; i <= 64; i++)
                enemy[i] = 0; // =D :)
            if (indxed[button_number] == 1 || cc == 1)
            {
                for (int i = 1; i <= 64; i++)
                {
                    if (indxed[i] == 2)
                    {
                        if (c[i] == "Pawn")
                        {
                            if (i % 8 != 0 && i + 9 <= 64)
                                enemy[i + 9] = 1;
                            if (i % 8 != 1 && i + 7 >= 1)
                                enemy[i + 7] = 1;
                        }
                        else if (c[i] == "Bishop")
                        {
                            if (a == 1)
                                x = p2.all_possible_move(i, arr);
                            else
                                x = p2.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Knight")
                        {
                            if (a == 1)
                                x = p3.all_possible_move(i, arr);
                            else
                                x = p3.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Rook")
                        {
                            if (a == 1)
                                x = p4.all_possible_move(i, arr);
                            else
                                x = p4.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Queen")
                        {
                            if (a == 1)
                                x = p5.all_possible_move(i, arr);
                            else
                                x = p5.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                    }
                }
            }
            else if (indxed[button_number] == 2 || cc == 2)
            {
                for (int i = 1; i <= 64; i++)
                {
                    if (indxed[i] == 1)
                    {
                        if (c[i] == "Pawn")
                        {
                            x = p1.all_possible_move(i, arr);
                            if (i % 8 != 0 && i - 9 >= 1)
                                enemy[i - 9] = 1;
                            if (i % 8 != 1 && i - 7 >= 1)
                                enemy[i - 7] = 1;
                        }
                        else if (c[i] == "Bishop")
                        {
                            if (a == 1)
                                x = p2.all_possible_move(i, arr);
                            else
                                x = p2.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Knight")
                        {
                            if (a == 1)
                                x = p3.all_possible_move(i, arr);
                            else
                                x = p3.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Rook")
                        {
                            if (a == 1)
                                x = p4.all_possible_move(i, arr);
                            else
                                x = p4.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (c[i] == "Queen")
                        {
                            if (a == 1)
                                x = p5.all_possible_move(i, arr);
                            else
                                x = p5.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                    }
                }
            }
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
             enemy_move(button_number, enemy, 0, -1); // -1 or -55415454524524
            if (button_number + 8 <= 64 && enemy[button_number + 8] == 0 && ((c[button_number + 8] == null) || (indxed[button_number] != indxed[button_number + 8])))
            {
                arr[i] = button_number + 8;
                i++;
            }
            if (button_number - 8 >= 1 && enemy[button_number - 8] == 0 && ((c[button_number - 8] == null) || (indxed[button_number] != indxed[button_number - 8])))
            {
                arr[i] = button_number - 8;
                i++;
            }
            if (button_number + 1 <= 64 && button_number % 8 != 0 && enemy[button_number + 1] == 0 && (c[button_number + 1] == null || indxed[button_number] != indxed[button_number + 1]))
            {
                arr[i] = button_number + 1;
                i++;
            }
            if (button_number - 1 >= 1 && button_number % 8 != 1 && enemy[button_number - 1] == 0 && (c[button_number - 1] == null || indxed[button_number] != indxed[button_number - 1]))
            {
                arr[i] = button_number - 1;
                i++;
            }
            ///////////////////////////////////////////////////////////////////////////////////////
            if (button_number + 9 <= 64 && button_number % 8 != 0 && enemy[button_number + 9] == 0 && (c[button_number + 9] == null || indxed[button_number] != indxed[button_number + 9]))
            {
                arr[i] = button_number + 9;
                i++;
            }
            if (button_number + 7 <= 64 && button_number % 8 != 1 && enemy[button_number + 7] == 0 && (c[button_number + 7] == null || indxed[button_number] != indxed[button_number + 7]))
            {
                arr[i] = button_number + 7;
                i++;
            }
            if (button_number - 9 >= 1 && button_number % 8 != 1 && enemy[button_number - 9] == 0 && (c[button_number - 9] == null || indxed[button_number] != indxed[button_number - 9]))
            {
                arr[i] = button_number - 9;
                i++;
            }
            if (button_number - 7 >= 1 && button_number % 8 != 0 && enemy[button_number - 7] == 0 && (c[button_number - 7] == null || indxed[button_number] != indxed[button_number - 7]))
            {
                arr[i] = button_number - 7;
                i++;
            }
            
            return i;
        }
        public bool Special_Move(int button_number, int[] arr)// دي فانكشن عشان التبيت او التحصين للملك
        {
            int i = 0;
            if (button_number == 61 && indxed[button_number] == 1 && indxed[button_number + 1] == 0 && indxed[button_number + 2] == 0 && indxed[button_number + 3] == 1 && chessGame.c[button_number + 3] == "Rook" && enemy[button_number + 2] == 0 && King.king1 == 0)
            {
                arr[i] = button_number + 2;
                i++;
            }
            if (button_number == 61 && indxed[button_number] == 1 && indxed[button_number - 1] == 0 && indxed[button_number - 2] == 0 && indxed[button_number - 3] == 0 && indxed[button_number - 4] == 1 && chessGame.c[button_number - 4] == "Rook" && enemy[button_number - 2] == 0 && King.king1 == 0)
            {
                arr[i] = button_number - 2;
                i++;
            }
            if (button_number == 5 && indxed[button_number] == 2 && indxed[button_number + 1] == 0 && indxed[button_number + 2] == 0 && indxed[button_number + 3] == 2 && chessGame.c[button_number + 3] == "Rook" && enemy[button_number + 2] == 0 && King.king2 == 0)
            {
                arr[i] = button_number + 2;
                i++;
            }
            if (button_number == 5 && indxed[button_number] == 2 && indxed[button_number - 1] == 0 && indxed[button_number - 2] == 0 && indxed[button_number - 3] == 0 && indxed[button_number - 4] == 2 && chessGame.c[button_number - 4] == "Rook" && enemy[button_number - 2] == 0 && King.king2 == 0)
            {
                arr[i] = button_number - 2;
                i++;
            }
            if (i != 0)
                return true;
            return false;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    if (chessGame.indxed[button_number1] == 1 && King.king1 == 0)
                        King.king1++;
                    else if (chessGame.indxed[button_number1] == 2 && King.king2 == 0)
                        King.king2++;
                    c[button_number2] = c[button_number1];
                    c[button_number1] = null;
                    indxed[button_number2] = indxed[button_number1];
                    indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
        public int kesh_king(int button_number, int[] friend)
        {
            int l = 0;
            for (int i = 1; i <= 64; i++)
            {
                if (chessGame.c[i] == "King" && indxed[button_number] != indxed[i])
                    button_numberx = i;
            }  
            if (chessGame.c[button_number] == "Pawn")
                w1 = p1.all_possible_move(button_number, friend);
            else if (chessGame.c[button_number] == "Bishop")
                w1 = p2.all_possible_move(button_number, friend);
            else if (chessGame.c[button_number] == "Knight")
                w1 = p3.all_possible_move(button_number, friend);
            else if (chessGame.c[button_number] == "Rook")
                w1 = p4.all_possible_move(button_number, friend);
            else if (chessGame.c[button_number] == "Queen")
                w1 = p5.all_possible_move(button_number, friend);
            for (int i = 0; i < w1; i++)
            {
                if (friend[i] == button_numberx)
                {
                    l++;
                }
            }
            if (l != 0)
                return w1;
            else
                return 0;
        }
        public int posible_move_when_kesh_king(int button_number, int[] move, int BUTTON, int ch, int[] kesh)
        {
            int i = 0, variable;
            w = 0;
            if (chessGame.c[button_number] == "Pawn")
                w = p1.all_possible_move(button_number, yy);
            else if (chessGame.c[button_number] == "Bishop")
                w = p2.all_possible_move(button_number, yy);
            else if (chessGame.c[button_number] == "Knight")
                w = p3.all_possible_move(button_number, yy);
            else if (chessGame.c[button_number] == "Rook")
                w = p4.all_possible_move(button_number, yy);
            else if (chessGame.c[button_number] == "Queen")
                w = p5.all_possible_move(button_number, yy);
            else if (chessGame.c[button_number] == "King")
                w = all_possible_move(button_number, yy);
            for (int j = 0; j < w; j++)
            {
                if (yy[j] == BUTTON)
                {
                    move[i] = BUTTON;
                    i++;
                }
                for (int k = 0; k < ch; k++)
                {
                    if (yy[j] == kesh[k])
                    {
                        s = c[kesh[k]];
                        var = indxed[kesh[k]];
                        c[kesh[k]] = c[button_number];
                        c[button_number] = null;
                        indxed[kesh[k]] = indxed[button_number];
                        indxed[button_number] = 0;
                        variable = kesh_king(BUTTON, friends);
                        if (variable == 0)
                        {
                            move[i] = yy[j];
                            i++;
                        }
                        c[button_number] = c[kesh[k]];
                        c[kesh[k]] = s;
                        indxed[button_number] = indxed[kesh[k]];
                        indxed[kesh[k]] = var;
                    }
                }
            }
            return i;
        }
        public bool test_before_move(int button_number)
        {
            for (int i = 1; i <= 64; i++)
                if (c[i] == "King" && indxed[button_number] == indxed[i])
                    button_numberx = i;
            enemy_move(button_number, enemy, 1, var);
            if (enemy[button_numberx] == 1)
                return false;
            return true;
        }
        public bool Draw_game(int player)
        {
            // لو اتبقي في اي جيم ملك قدام ملك يبقي تعادل 
            // first case of draw
            int k = 0, bishop = 0, knight = 0;
            for (int i = 1; i <= 64; i++)
                if (c[i] == null)
                    k++;
            if (k == 62)
                return true;
            //////////////////////////////////////////////////////////////////
            // لو اتبقي في اي جيم ملك قدام ملك وفيل واحد يبقي تعادل 
            // لو اتبقي في اي جيم ملك قدام ملك وحصان واحد يبقي تعادل
            // second case of draw
            k = 0;
            for (int i = 1; i <= 64; i++)
                if (c[i] == null)
                    k++;
                else if (c[i] == "Bishop")
                    bishop++;
                else if (c[i] == "Knight")
                    knight++;
            if (k == 61 && (bishop == 1 || knight == 1))
                return true;
            /////////////////////////////////////////////////////////////////
            // لو مثلا اللاعب الابيض هو اللي عليه الدور ومعندوش اي حركة لاي قطعة (حتي الملك نفسه) والملك بتاعه مش في وضع الكش يبقي تعادل
            // third case of draw
            int x = 0;
            for (int i = 1; i <= 64; i++)
            {
                if (c[i] == "Pawn" && indxed[i] == player)
                    x += p1.all_possible_move(i, arr);
                else if (c[i] == "Bishop" && indxed[i] == player)
                    x += p2.all_possible_move(i, arr);
                else if (c[i] == "Knight" && indxed[i] == player)
                    x += p3.all_possible_move(i, arr);
                else if (c[i] == "Rook" && indxed[i] == player)
                    x += p4.all_possible_move(i, arr);
                else if (c[i] == "Queen" && indxed[i] == player)
                    x += p5.all_possible_move(i, arr);
                else if (c[i] == "King" && indxed[i] == player)
                    x += all_possible_move(i, arr);
            }
            if (x == 0) // ده معناه ان مفيش اي حركة للفريق اللي المفروض عليه الدور في اللعب 
                return true;
            return false;
        }
        public bool check_for_end_game(int button_number)
        {
            int v = 0;
            for (int i = 1; i <= 64; i++)
            {
                if (chessGame.c[i] == "King" && indxed[button_number] != indxed[i])
                    button_numberx = i;
            }
            for (int i = 1; i <= 64; i++)
            {
                if (indxed[button_number] == indxed[i])
                {
                    variable = kesh_king(i, xx);
                    if (variable != 0)
                    {
                        ccc = variable;
                        for (int q = 0; q < variable; q++)
                            xxx[q] = xx[q];
                        but = i;
                        v++;
                    }
                }
            }
            if (v == 0)
            {
                return false;
            }
            if (v >= 2)
            {
                int x = all_possible_move(button_numberx, arr1);
                if (x != 0)
                {
                    return false;
                }
            }
            else if (v == 1)
            {
                int x = all_possible_move(button_numberx, arr1);
                if (x != 0)
                    return false;
                for (int i = 1; i <= 64; i++)
                {
                    if (indxed[button_number] != indxed[i])
                    {
                        int ww = posible_move_when_kesh_king(i, arr1, but, ccc, xxx);
                        if (ww != 0)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
