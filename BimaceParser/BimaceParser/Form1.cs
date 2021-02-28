using System;
using System.Windows.Forms;

using BimaceParser.Models;
using BimaceParser.Exchange;

namespace BimaceParser
{
    public partial class Form1 : Form
    {
        private BinanceExchange Binance = new BinanceExchange();

        public Form1()
        {
            InitializeComponent();

            Binance.OnIterationCompleted += Binance_OnIterationCompleted;
            Binance.OnPairsUpdated += Binance_OnPairsUpdated;
        }

        private void UpdatePairsButton_Click(object sender, EventArgs e)
        {
            Binance.UpdatePairs();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Binance.Pause = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Binance.Pause = true;
        }

        private void PairSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Binance.SelectedSymbol = PairSelector.SelectedItem as Symbol;
        }

        private void Binance_OnPairsUpdated(object sender, EventArgs e)
        {
            Action action = () =>
            {
                PairSelector.Items.Clear();
                PairSelector.Items.AddRange(Binance.Pairs.Symbols);
            };

            this.Invoke(action);
        }

        private void Binance_OnIterationCompleted(object sender, EventArgs e)
        {
            PrintStats(Binance.Stats);
            PrintOrderBook(Binance.OrderBook);
            PrintRecentTradesList(Binance.RecentTradesList);
        }

        private void PrintStats(Stats stats)
        {
            textBox1.AppendText($"{stats.Symbol}; {stats.LastPrice}; {stats.PriceChange}; {stats.HighPrice}; {stats.LastPrice}; {stats.Volume}; {stats.QuoteVolume}\r\n");
            textBox1.ScrollToCaret();
        }

        private void PrintOrderBook(OrderBook order)
        {
            textBox2.Clear();

            for (int i = order.Asks.Length - 5; i >= 0; i--)
            {
                textBox2.AppendText($"{order.Asks[i][0]}   {order.Asks[i][1]} \t|  {order.Bids[i][0]}   {order.Bids[i][1]}\r\n");
            }
        }

        private void PrintRecentTradesList(RecentTradesInfo[] tradesList)
        {
            foreach(RecentTradesInfo item in tradesList)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(item.Time).ToLocalTime();
                textBox3.AppendText($"{item.Price}  {item.Quantity}  {origin.ToString()}\r\n");
            }

            textBox3.ScrollToCaret();
        }
    }
}
