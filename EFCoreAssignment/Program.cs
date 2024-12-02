namespace EFCoreAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To test you functionality, you can create an instance of your DbContext,
            // then create an instance of your repository and pass the db context to it,
            // then crate an instance of your service and json/xml converter and pass the repository and json/xml converter to the service
            // and finally create an instance of your controller and pass the service to it.
            // Then you can call the methods of the controller to test your functionality.
            // Here is an example:

            /// context = new DbContext();
            /// repository = new Repository(context);
            /// converter = new Converter();
            /// service = new Service(repository, converter);
            /// controller = new Controller(service);
            /// 
            /// conteoller.getall();
            /// 


            // WHEN INSTANTIATING STORE THE INSTANCE IN THE CONTACT TYPE, NOT THE ACTUAL CLASS
            // EXMAPLE:

            /// IBaseRepository<Book> repository = new BookRepository(context);
            /// IBaseService service = new BookService(repository, converter);

        }
    }
}
