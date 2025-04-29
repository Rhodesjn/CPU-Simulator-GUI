using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        // First Come First Serve Algorithm
        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np];
            double[] wtp = new double[np];
            string[] output1 = new string[npX2];
            double twt = 0.0, awt; 
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    //MessageBox.Show("Enter Burst time for P" + (num + 1) + ":", "Burst time for Process", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Console.WriteLine("\nEnter Burst time for P" + (num + 1) + ":");

                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToInt64(input);

                    //var input = Console.ReadLine();
                    //bp[num] = Convert.ToInt32(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                        MessageBox.Show("Waiting time for P" + (num + 1) + " = " + wtp[num], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                awt = twt / np;
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + awt + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
                //this.Hide();
                //Form1 frm = new Form1();
                //frm.ShowDialog();
            }
        }
        //Shortest Job First Algorithm
        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] bp = new double[np];
            double[] wtp = new double[np];
            double[] p = new double[np];
            double twt = 0.0, awt; 
            int x, num;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    p[num] = bp[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (p[num] > p[num + 1])
                        {
                            temp = p[num];
                            p[num] = p[num + 1];
                            p[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + p[num - 1];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Priority Scheduling Algorithm
        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] bp = new double[np];
                double[] wtp = new double[np + 1];
                int[] p = new int[np];
                int[] sp = new int[np];
                int x, num;
                double twt = 0.0;
                double awt;
                int temp = 0;
                bool found = false;
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    p[num] = Convert.ToInt16(input2);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    sp[num] = p[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (sp[num] > sp[num + 1])
                        {
                            temp = sp[num];
                            sp[num] = sp[num + 1];
                            sp[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + bp[temp];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("\n\nAverage waiting time: " + (awt = twt / np));
                //Console.ReadLine();
            }
            else
            {
                //this.Hide();
            }
        }
        //Round Robin Algorithm
        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int i, counter = 0;
            double total = 0.0;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTime = new double[10];
            double[] burstTime = new double[10];
            double[] temp = new double[10];
            int x = np;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < np; i++)
                {
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    arrivalTime[i] = Convert.ToInt64(arrivalInput);

                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    burstTime[i] = Convert.ToInt64(burstInput);

                    temp[i] = burstTime[i];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToInt64(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                for (total = 0, i = 0; x != 0;)
                {
                    if (temp[i] <= timeQuantum && temp[i] > 0)
                    {
                        total = total + temp[i];
                        temp[i] = 0;
                        counter = 1;
                    }
                    else if (temp[i] > 0)
                    {
                        temp[i] = temp[i] - timeQuantum;
                        total = total + timeQuantum;
                    }
                    if (temp[i] == 0 && counter == 1)
                    {
                        x--;
                        //printf("nProcess[%d]tt%dtt %dttt %d", i + 1, burst_time[i], total - arrival_time[i], total - arrival_time[i] - burst_time[i]);
                        MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (total - arrivalTime[i]), "Turnaround time for Process " + (i + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (total - arrivalTime[i] - burstTime[i]), "Wait time for Process " + (i + 1), MessageBoxButtons.OK);
                        turnaroundTime = (turnaroundTime + total - arrivalTime[i]);
                        waitTime = (waitTime + total - arrivalTime[i] - burstTime[i]);                        
                        counter = 0;
                    }
                    if (i == np - 1)
                    {
                        i = 0;
                    }
                    else if (arrivalTime[i + 1] <= total)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(waitTime * 1.0 / np);
                averageTurnaroundTime = Convert.ToInt64(turnaroundTime * 1.0 / np);
                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
            }
        }
        //Multi-Level Feedback Queue (MLFQ) Scheduling.
        public static void mlfqAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int[] arrivalTime = new int[np];
            int[] burstTime = new int[np];
            int[] remainingTime = new int[np];
            int[] completionTime = new int[np];

            // Prompt for arrival and burst times.
            for (int i = 0; i < np; i++)
            {
                string inputArrival = Microsoft.VisualBasic.Interaction.InputBox("Enter Arrival time for P" + (i + 1),
                                                        "MLFQ Scheduling", "", -1, -1);
                arrivalTime[i] = Convert.ToInt32(inputArrival);

                string inputBurst = Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time for P" + (i + 1),
                                                        "MLFQ Scheduling", "", -1, -1);
                burstTime[i] = Convert.ToInt32(inputBurst);

                remainingTime[i] = burstTime[i];
            }

            // Prompt for time quantums for level 0 and level 1.
            string q0Input = Microsoft.VisualBasic.Interaction.InputBox("Enter Time Quantum for Level 0",
                                                    "MLFQ Scheduling", "4", -1, -1);
            int quantum0 = Convert.ToInt32(q0Input);
            string q1Input = Microsoft.VisualBasic.Interaction.InputBox("Enter Time Quantum for Level 1",
                                                    "MLFQ Scheduling", "6", -1, -1);
            int quantum1 = Convert.ToInt32(q1Input);

            // Two queues representing the two levels.
            Queue<int> queue0 = new Queue<int>();
            Queue<int> queue1 = new Queue<int>();

            // Boolean array to track whether a process has been added to any queue.
            bool[] added = new bool[np];

            int t = 0;
            int completed = 0;

            // Simulation loop until all processes finish.
            while (completed < np)
            {
                // Add any processes that have arrived and not yet enqueued.
                for (int i = 0; i < np; i++)
                {
                    if (arrivalTime[i] <= t && !added[i])
                    {
                        queue0.Enqueue(i);
                        added[i] = true;
                    }
                }

                if (queue0.Count > 0)
                {
                    int idx = queue0.Dequeue();
                    int execTime = Math.Min(quantum0, remainingTime[idx]);
                    // Execute the process for its allotted time slice.
                    for (int j = 0; j < execTime; j++)
                    {
                        t++;
                        remainingTime[idx]--;

                        // Check for any new arrivals during execution.
                        for (int i = 0; i < np; i++)
                        {
                            if (arrivalTime[i] <= t && !added[i])
                            {
                                queue0.Enqueue(i);
                                added[i] = true;
                            }
                        }
                        if (remainingTime[idx] == 0)
                            break;
                    }
                    if (remainingTime[idx] == 0)
                    {
                        completionTime[idx] = t;
                        completed++;
                    }
                    else
                    {
                        // Process did not finish; demote to level 1.
                        queue1.Enqueue(idx);
                    }
                }
                else if (queue1.Count > 0)
                {
                    int idx = queue1.Dequeue();
                    int execTime = Math.Min(quantum1, remainingTime[idx]);
                    // Execute from level 1.
                    for (int j = 0; j < execTime; j++)
                    {
                        t++;
                        remainingTime[idx]--;

                        // New arrivals always go to level 0.
                        for (int i = 0; i < np; i++)
                        {
                            if (arrivalTime[i] <= t && !added[i])
                            {
                                queue0.Enqueue(i);
                                added[i] = true;
                            }
                        }
                        if (remainingTime[idx] == 0)
                            break;
                    }
                    if (remainingTime[idx] == 0)
                    {
                        completionTime[idx] = t;
                        completed++;
                    }
                    else
                    {
                        // Re-enqueue in level 1 if still not done.
                        queue1.Enqueue(idx);
                    }
                }
                else
                {
                    // If no process is available, idle the CPU.
                    t++;
                }
            }

            double totalWaiting = 0;
            int[] waitingTime = new int[np];

            // Calculate waiting time = turnaround time – burst time.
            for (int i = 0; i < np; i++)
            {
                int turnaroundTime = completionTime[i] - arrivalTime[i];
                waitingTime[i] = turnaroundTime - burstTime[i];
                totalWaiting += waitingTime[i];
                MessageBox.Show("Waiting time for P" + (i + 1) + " = " + waitingTime[i],
                                "MLFQ Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            double averageWaiting = totalWaiting / np;
            MessageBox.Show("Average Waiting Time for " + np + " processes = " + averageWaiting,
                            "MLFQ Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Shortest Remaining Time First (SRTF)
        public static void srtfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int[] arrivalTime = new int[np];
            int[] burstTime = new int[np];
            int[] remainingTime = new int[np];
            int[] completionTime = new int[np];
            int[] waitingTime = new int[np];

            // Get arrival and burst times for each process.
            for (int i = 0; i < np; i++)
            {
                string inputArrival = Microsoft.VisualBasic.Interaction.InputBox("Enter Arrival time for P" + (i + 1),
                                                        "SRTF Scheduling", "", -1, -1);
                arrivalTime[i] = Convert.ToInt32(inputArrival);

                string inputBurst = Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time for P" + (i + 1),
                                                        "SRTF Scheduling", "", -1, -1);
                burstTime[i] = Convert.ToInt32(inputBurst);

                remainingTime[i] = burstTime[i];
            }

            int t = 0; // current time
            int completed = 0;

            // Simulate until all processes complete.
            while (completed < np)
            {
                int idx = -1;
                int minRem = int.MaxValue;
                for (int i = 0; i < np; i++)
                {
                    if (arrivalTime[i] <= t && remainingTime[i] > 0 && remainingTime[i] < minRem)
                    {
                        minRem = remainingTime[i];
                        idx = i;
                    }
                }

                if (idx == -1)
                {
                    // CPU is idle if no process has arrived.
                    t++;
                }
                else
                {
                    // Execute the process for one time unit.
                    remainingTime[idx]--;
                    t++;

                    if (remainingTime[idx] == 0)
                    {
                        completionTime[idx] = t;
                        completed++;
                    }
                }
            }

            double totalWaiting = 0;

            // Calculate waiting time: waiting = completion time – arrival time – burst time.
            for (int i = 0; i < np; i++)
            {
                waitingTime[i] = completionTime[i] - arrivalTime[i] - burstTime[i];
                totalWaiting += waitingTime[i];
                MessageBox.Show("Waiting time for P" + (i + 1) + " = " + waitingTime[i],
                                "SRTF Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            double averageWaiting = totalWaiting / np;
            MessageBox.Show("Average Waiting Time for " + np + " processes = " + averageWaiting,
                            "SRTF Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

