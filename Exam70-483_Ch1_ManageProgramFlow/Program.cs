using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70_483_Ch1_ManageProgramFlow
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        static void Task1()
        {
            Console.WriteLine("Start executing Task 1");
            Thread.Sleep(2000);
            Console.WriteLine("Finish Executing Task 1");
        }

        static void Task2()
        {
            Console.WriteLine("Start executing Task 2");
            Thread.Sleep(2000);
            Console.WriteLine("Finish Executing Task 2");
        }

        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static bool CheckCity(string name)
        {
            if (name == "")
                throw new ArgumentException(name);
            return name == "Seattle";
        }

        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        public static void DoWork(int i)
        {
            Console.WriteLine("Task {0} starting", i);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} finished", i);
        }

        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }

        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(2000);
            Console.WriteLine("World");
        }

        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child {0} finished", state);
        }

        static void ThreadHello()
        {
            Console.WriteLine("Start thread");
            Thread.Sleep(2000);
            Console.WriteLine("End thread");
        }

        static void WorkOnData(object data)
        {
            Console.WriteLine("Started Working on: {0}", data);
            Thread.Sleep(2000);
            Console.WriteLine("Started Working on: {0}", data);
        }

        static bool tickRunning; // flag variable

        public static ThreadLocal<Random> RandomGenerator = new ThreadLocal<Random>(() =>        {
            return new Random(2);        });

        static void /* async Task */ Main(string[] args)
        {
            //Console.WriteLine("Started Invoke...");
            //Parallel.Invoke(()=>Task1(),
            //    ()=>Task2(),
            //    ()=> {
            //        Console.WriteLine("Start executing Task 3");
            //        Thread.Sleep(2000);
            //        Console.WriteLine("Finish Executing Task 3");
            //    });
            //Console.WriteLine("Terminated Invoke...");

            //Console.WriteLine("Started ForEach...");
            //var items1 = Enumerable.Range(0, 50);
            //Parallel.ForEach(items1, item => {
            //    WorkOnItem(item);
            //});
            //Console.WriteLine("Terminated ForEach...");

            //Console.WriteLine("Started For...");
            //var items2 = Enumerable.Range(0, 50).ToArray();
            //Parallel.For(0, items2.Length, i =>
            //{
            //    WorkOnItem(items2[i]);
            //});
            //Console.WriteLine("Terminated For...");

            //Console.WriteLine("Started For with parallel loop state...");
            //var items3 = Enumerable.Range(0, 500).ToArray();
            //ParallelLoopResult result = Parallel.For(0, items3.Count(), (int i, ParallelLoopState
            //loopState) =>
            //{
            //    if (i == 200)
            //        loopState.Break();

            //    WorkOnItem(items3[i]);
            //});
            //Console.WriteLine("Completed: " + result.IsCompleted);
            //Console.WriteLine("Items: " + result.LowestBreakIteration);
            //Console.WriteLine("Terminated For with parallel loop state...");

            Person[] people = {                    new Person { Name = "Alan", City = "Hull" },                    new Person { Name = "Beryl", City = "Seattle" },                    new Person { Name = "Charles", City = "London" },                    new Person { Name = "David", City = "Seattle" },                    new Person { Name = "Eddy", City = "Paris" },                    new Person { Name = "Fred", City = "Berlin" },                    new Person { Name = "Gordon", City = "Hull" },                    new Person { Name = "Nikos", City = "" },                    new Person { Name = "Henry", City = "Seattle" },                    new Person { Name = "Isaac", City = "Seattle" },                    new Person { Name = "James", City = "London" }};
            //
            //var result = from person in people.AsParallel().AsOrdered().WithDegreeOfParallelism(2).WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //             where person.City == "Seattle"
            //             select person;
            //
            //var result = (from person in people.AsParallel()
            //              where person.City == "Seattle"
            //              orderby (person.Name)
            //              select new
            //              {
            //                  Name = person.Name
            //              }).AsSequential().Take(4);


            //foreach (var person in result)
            //    Console.WriteLine(person.Name);

            //var result = from person in people.AsParallel()
            //             where person.City == "Seattle"
            //             select person;
            //result.ForAll(person => Console.WriteLine(person.Name));

            //try
            //{
            //    var result = from person in
            //    people.AsParallel()
            //                 where CheckCity(person.City)
            //                 select person;
            //    result.ForAll(person => Console.WriteLine(person.Name));
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            //}

            //Task task = new Task(() => DoWork());
            //task.Start();
            //task.Wait();

            //Task task = Task.Run(() => DoWork());
            //task.Wait();

            //Task<int> task = Task.Run(()=> {
            //    return CalculateResult();
            //});
            //Console.WriteLine(task.Result);

            //Task[] tasks = new Task[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    int taskNum = i; // make a local copy of the loop counter so that the
            //                     // correct task number is passed into the lambda expression            //    tasks[i] = Task.Run(() => DoWork(taskNum));
            //    //tasks[i].Wait();
            //}
            //Task.WaitAll(tasks); //Task.Waitany(tasks);

            //Task task = Task.Run(() => HelloTask());
            //await task.ContinueWith((prevTask) => WorldTask());

            //Task task = Task.Run(() => HelloTask());
            //await task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            //await task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            //var parent = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Parent starts...");
            //    for(int i = 0; i < 10; i++)
            //    {
            //        int taskNo = i;
            //        Task.Factory.StartNew(
            //            (x) => DoChild(x), // lambda expression
            //            taskNo, // state object
            //            TaskCreationOptions.AttachedToParent);
            //    }
            //});
            //parent.Wait();

            //Thread thread1 = new Thread(ThreadHello);
            //thread1.Start();

            //ThreadStart ts = new ThreadStart(ThreadHello);
            //Thread thread2 = new Thread(ts);
            //thread2.Start();

            //Thread thread3 = new Thread(() => {
            //    Console.WriteLine("Thread 3 started");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Thread 3 ended");
            //});
            //thread3.Start();

            //ParameterizedThreadStart pts = new ParameterizedThreadStart(WorkOnData);
            //Thread thread = new Thread(pts);
            //thread.Start(99);

            //Thread thread4 = new Thread((data) => {
            //    WorkOnData(data);
            //});
            //thread4.Start(99);

            //Thread thread5 = new Thread(() => {
            //    while (true)
            //    {
            //        Console.WriteLine("Tick");
            //        Thread.Sleep(1000);
            //    }
            //});

            //thread5.Start();

            //Console.WriteLine("Press a key to stop thread execution");
            //Console.ReadKey();

            //thread5.Abort();

            //tickRunning = true;
            //Thread tickThread = new Thread(() =>
            //{
            //    while (tickRunning)
            //    {
            //        Console.WriteLine("Tick");
            //        Thread.Sleep(1000);
            //    }
            //});
            //tickThread.Start();
            //Console.WriteLine("Press a key to stop the clock");
            //Console.ReadKey();
            //tickRunning = false;

            //Thread threadToWaitFor = new Thread(() =>
            //{
            //    Console.WriteLine("Thread starting");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Thread done");
            //});
            //threadToWaitFor.Start();
            //Console.WriteLine("Joining thread");
            //threadToWaitFor.Join();

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();

            //
            Console.WriteLine("Program Termination");
        }
    }
}
