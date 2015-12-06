# Factory Method
The Factory Method pattern defines an interface for creating an object where the subclasses decide which class to instantiate.

### Structure
The structural example can be found in **FactoryMethodStructure.cs**. Note how in the MainApp class endpoint where we are actually using the factory method our calls to create the instances of the product classes are fairly ambiguous.

- **Product** - This is the abstraction of a base class that would be used for the subclasses which can be created by the Creator.
- **ConcreteProduct** - The actual classes that will get instantiated by the creator.
- **Creator** - An abstract class that allows us to interface with the concrete creators.
- **ConcreteCreator** - The actual classes that decide what products to instantiate.

### Example
Let's take into consideration a game where we need to build a variety of types of books.

- **FactoryMethodExampleAbstractions.cs**
  - **Page** This is a base class from which we will create our subclasses (our concrete pages). It has a constructor that assigns the class fields and does some work to create the game object structure for a page. I added in some methods for getting, setting, and adding to the text contents of the pages.
  - **Document** This is the 'abstract Creator' for the pattern. It has a constructor to make a parent game object to hold all of our pages, an abstract method to create pages (all Creators need to define how this is done. Note that the constructor also calls CreatePages which is actually defined in the subclasses. It also has a common method to automatically fill out the table of contents page.

- **ConcretePages.cs** - Here we define our actual pages and basically each page just has a constructor that only adds to the base constructor by setting the name of the 'page' game object in the Page class.

- **ConcreteDocuments.cs** - Here we define our 'ConcreteCreator' classes. They have a constructor which adds to the base class's constructor and sets the name on the documentHolder game object to the name of the concrete document class (i.e. ChracterSheet, SpellBook). Then we have our required definition of CreatePages. CreatePages makes each concrete page via its constructor, adds them to the _page List for the document, and finally sets the table of contents list.

- **DocumentMaker.cs** - This is our MonoBehaviour class that will run the Document creators and then it has a simple coroutine that flips through the pages so we can see them all there.

### Afterthoughts
This pattern feels a bit heavy and very similar to a Builder pattern. The main difference is that in the Factory Method pattern the subclasses are deciding how to put the products (pages) together to form the final product. In the Builder pattern the 'Director' class tells the 'Builder' classes how to construct their final products. I'd love to have a discussion on the differences between this pattern and the Builder pattern. Anyone interested can start an issue where we can discuss it!



