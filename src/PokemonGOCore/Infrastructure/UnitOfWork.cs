using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Web;

namespace PokemonGOCore.Infrastructure
{
    public static class UnitOfWork
    {
        private const string UNIT_OF_WORK = "INNOVO_UNIT_OF_WORK";
        private static readonly ConcurrentDictionary<string, PokemonGOContext> _threads = new ConcurrentDictionary<string, PokemonGOContext>();
        private static Guid UnitTestContext = Guid.Empty;

        private static bool ContextExists()
        {
            return HttpContext.Current.Items.Contains(UNIT_OF_WORK);
        }


        public static PokemonGOContext Context
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (!ContextExists())
                    {
                        PokemonGOContext context = new PokemonGOContext();
                        HttpContext.Current.Items.Add(UNIT_OF_WORK, context);
                    }
                    return (PokemonGOContext)HttpContext.Current.Items[UNIT_OF_WORK];
                }
                else
                {
                    //if (UnitTestContext == Guid.Empty)
                    //{
                    //    throw new Exception("Set a unit test context");
                    //}
                    //else
                    //{
                    //    if (_threads[UnitTestContext.ToString()] == null)
                    //    {
                    //        _threads[UnitTestContext.ToString()] = new JanssenOneContext();
                    //    }
                    //    return (JanssenOneContext)_threads[UnitTestContext.ToString()];
                    //}

                    Thread thread = Thread.CurrentThread;
                    if (string.IsNullOrEmpty(thread.Name))
                    {
                        thread.Name = Guid.NewGuid().ToString();
                    }
                    if (!_threads.ContainsKey(Thread.CurrentThread.Name))
                    {
                        var context = new PokemonGOContext();
                        context.Configuration.AutoDetectChangesEnabled = false;
                        context.Configuration.ValidateOnSaveEnabled = false;
                        _threads[Thread.CurrentThread.Name] = context;
                    }
                    return (PokemonGOContext)_threads[Thread.CurrentThread.Name];


                }
            }
        }


        /// <summary>
        /// Throw is commented because exceptions are being treated on the service.
        /// </summary>
        public static void Close()
        {
            try
            {
                if (ContextExists())
                {
                    Context.SaveChanges();
                    Context.Dispose();
                }
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items.Contains(UNIT_OF_WORK))
                    {
                        HttpContext.Current.Items.Remove(UNIT_OF_WORK);
                    }
                }
                else
                {
                    PokemonGOContext v;
                    _threads.TryRemove(Thread.CurrentThread.Name, out v);
                }
            }
            catch (Exception ex)
            {
                //Logging.Logger.Error(ex);
            }
        }

        public static void SetContext(Guid guid)
        {
            UnitTestContext = guid;
        }
    }
}