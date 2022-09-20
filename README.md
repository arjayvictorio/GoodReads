
**

## Good Reads API

**

**Objectives/Problem**
Create a Web API that can be used to store read books.

**Specific Objectives:**
1. Create a Method that will accept a Book Object that will be saved to the database
2. Create a Method that will fetch all the read books from the database
3. Create a Method that will fetch an individual book from the read database table by name

**Solution:**
Create a Web API using the test driven method

**Steps (Phase 1 - Initialize Project Solution)**
1. Create a blank solution
2. Create a MSUnit test Project (**Unit test**)
3. Create a Class Library Project that will hold the business logic (**Business Logic**)
4. Create a Class Library Project that will hold the object model (**Database Service**. We will be using this for the models only since we are using an in-memory database)
5. Create a Web API Project (**API**)

**Steps (Phase 2 - TDD Saving Book to Database)**
1. (*Unit Test*) Create a unit test for Saving a Book to the database (both test will fail for now, this is part of the tdd).
	

    public void test_Save_Pass() 
	

    public void test_Save_Fail()

2. (*Database Service*) Create a book class (Id, Name, Description, Error)

3. (*API*) Create a DBContext (we will be using in-memory as a database, install it from nuget)

4. (*API*) Add the DBContext to Services from Program.cs (for dependency injection on our main api controller)
	

    builder.Services.AddDbContext<ApiContext>
        	(opt => opt.UseInMemoryDatabase("ReadsDB"));

5. (*API*) Create an Interface for our Service ('IBookService') with the method
	Book Save(Book book);
	

> Note: Use of Interface

6. (*API*) Create a class 'BookService' that implements the 'IBookService' Interface; implement the interface
	

> Note: Implementing an Interface

7. (*API*) Create an Initialization for the BookService that accepts an APIContext as parameter

8. (*Business Logic*) Create a class that will check the validity of data of a Book object
	

    public class Validator
		

    public bool isValid(Book book)

9. (*API*) Update the BookService to use the Validator to check the validity of data of a book before saving it to the database

10. (*API*) Create a controller 'ReadController', then create a httpget method
	Public Book Save(Book book)	

11. (API) Create an initialization method for the ReadController that accepts a an APIContext as parameter
	  private readonly ApiContext _context;

        public ReadController(ApiContext context)
        {
            _context = context;
        }

	

> Note: Dependency Injection

12. (*API*) in the ReadController, update the Save method to actualy save the data
	  

    [HttpGet("Save")]
            public Book Save(Book book)
            {
               return new BookService(_context).Save(book);
            }

13.(*Unit Test*) Create a test for Pass and Fail
	

    public void test_Save_Pass()
	public void test_Save_Fail()

14. Run the Web API for manual testing using swagger

15. Run the Unit test for automated test


**Steps (Phase 3 - TDD View List of Books)**

1. (*Unit Test*) Create a test that will fetch the records from the database of read books (this will fail for now)
	

    public void test_Fetch_3()
	

    public void test_Fetch_0()

2. (*API)* we will simply create an extended method for our BookService using a static class and static method (this is simply to show that we can easily extend our codes)
	

    public static class ExtendedBookService
    		public static List<Book> GetAll(this BookService bs, ApiContext apiContext)
	

> Note: using extended method to extend the current code/class

3. (*API*) Create GetAll method on ReadController, and use the BookService to return a list of read books from the database
	

    public List<Book> GetAll()
    		return new BookService(_context).GetAll(_context);

4. Run the Web API for manual testing using swagger

5. Run the Unit test for automated test


**Steps (Phase 4 - TDD Get Book by Name)**

1. (*Unit Test*) Create a test that will fetch a record based on book name (this will fail for now)
	

    public void test_Fetch_Book_1()
    	public void test_Fetch_Book_0()

2. (*API*) we will simply create an extended method for our BookService using the ExtendedBookService class and static method (this is simply to show that we can easily extend our codes)
	

    public static class ExtendedBookService
    		public static Book Get(this BookService bs, ApiContext apiContext, string name)
	

> Note: using extended method to extend the current code/class

3. (*API*) Create Fetch method on ReadController, and use the BookService to return a book from the database
	

    public Book Fetch(string name)
    		return new BookService(_context).Get(_context, name);

4. Run the Web API for manual testing using swagger

5. Run the Unit test for automated test
