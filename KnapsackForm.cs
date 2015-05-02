using System;
using System.Windows.Forms;

namespace Knapsack
{
    public partial class KnapsackForm : Form
    {
        int[] _values;
        int[] _weights;
        int[] _appliance;

        public KnapsackForm()
        {
            InitializeComponent();
        }

        int knapsack(int[] weights, int[] values, int capacity, int numberOfItems, out int[,][] usages)
        {
            var fullNumber = weights.Length;
            int[,] dp = new int[capacity + 1, fullNumber + 1];
            usages = new int[capacity + 1, fullNumber + 1][];
            // дополнительно формируем массивы для запоминания того, какие предметы сколько раз были добавлены в рюкзак
            for (int i = 0; i <= fullNumber; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    usages[j, i] = new int[numberOfItems];
                }
            }

            for (int i = 1; i < fullNumber + 1; i++) // для каждого возможного использования количества предметов
            {
                for (int w = 1; w < capacity + 1; w++) // для каждой возрастающей емкости рюкзака
                {
                    // копируем индексы предметов, которые были добавлены для получения текущей ценности
                    for (var k = 0; k < numberOfItems; k++)
                        usages[w, i][k] = usages[w, i - 1][k];
                    if (weights[i - 1] <= w) // если новый предмет в принципе впихивается в рюкзак
                    {
                        // то пытаемся впихнуть его, или оставить предыдущее решение
                        dp[w, i] = Math.Max(dp[w, i - 1], dp[w - weights[i - 1], i - 1] + values[i - 1]);
                        // если мы впихнули новый элемент, то увеличиваем индекс добавленного предмета
                        if (dp[w, i - 1] < dp[w - weights[i - 1], i - 1] + values[i - 1])
                        {
                            for (var k = 0; k < numberOfItems; k++)
                                usages[w, i][k] = usages[w - weights[i - 1], i - 1][k];
                            usages[w, i][_appliance[i - 1]]++;
                        }
                    }
                    else
                    {
                        // оставляем предыдущее решение
                        dp[w, i] = dp[w, i - 1];
                    }
                }
            }

            return dp[capacity, fullNumber];
        }

        private void solve_Click(object sender, EventArgs e)
        {
            int number;
            int fullNumber;
            int capacity;
            int[,][] usages;

            output.Clear();

            var inputDataRows = input.Text.Split("\n".ToCharArray());
            capacity = Convert.ToInt32(inputDataRows[0]);

            number = inputDataRows.Length - 1;
            fullNumber = 0;
            for (int i = 1; i < inputDataRows.Length; i++)
                fullNumber += (int)Math.Floor(capacity / Convert.ToDouble(inputDataRows[i].Split(' ')[1]));

            _values = new int[fullNumber];
            _weights = new int[fullNumber];
            _appliance = new int[fullNumber];

            var k = 0;
            for (int i = 1; i < inputDataRows.Length; i++)
            {
                var row = inputDataRows[i].Split(' ');
                var thisNum = (int)Math.Floor(capacity / Convert.ToDouble(row[1]));
                for (int j = 0; j < thisNum; j++)
                {
                    _values[k] = Convert.ToInt32(row[0]);
                    _weights[k] = Convert.ToInt32(row[1]);
                    _appliance[k] = i - 1;
                    k++;
                }
            }
            var result = knapsack(_weights, _values, capacity, number, out usages);

            output.Text += result.ToString() + "\r\n";
            for (int i = 0; i < number; i++)
            {
                if (usages[capacity, fullNumber][i] == 0) continue;
                output.Text += string.Format("Предмет №{0} кладем {1} раз(а)\r\n", i + 1, usages[capacity, fullNumber][i]);
            }
        }
    }
}
