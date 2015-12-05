# Contibutors Welcome!

## Guidelines

### Table of Contents
- [How to Contribute](#how-to-contribute)
- [Repository Structure](#repository-structure)
- [Coding Guidelines](#coding-guidelines)
- [Updating your Pull Request](#updating-your-pull-request)

#### How to Contribute
Contributing is easy! Just fork this repository to your own GitHub account, make the changes you want then submit a pull request to the **development** branch. All forks should merge into **development** as this will provide us with the opportunity to make test them out before merging into the master branch for public consumption. 

Changes to folder structure or .gitignore should be discussed in an **issue** before attempting them.

Your Unity project should be set to have visible meta files (Edit -> Project Settings -> Editor) and force text.

Make sure to include a readme.md for each pattern and update them when you update the pattern if an explanation needs to be conveyed to the public.


#### Repository Structure
The folder structure should remain quite simple:  
- Each pattern should be in its own folder under Assets.
- In these folders there should be a folder "example" and a folder "structure". "Structure" will just illustrate the patterns structure and is only good for reference. "Example" will actually contain the class files for a real-world example that will run in an example scene also contained in that folder.
  - assets/pattern name/structure
  - assets/pattern name/example
- Classes for each structure and each example should be wrapped in their own namespace so that they have a very low chance of interfering with another person's project should they import the classes.

#### Coding Guidelines
- Each example and each structure should be contained in their own namespace.
- Each file should normally contain one class unless the included classes are directly related and very small (like abstracts classes in a pattern structure).
- Use comments liberally, but if something is clear then don't comment it (i.e. don't include comments like Unity's default "//Use this for initialization" where 99% of the people already should understand what the Start() method does). 
- Format your code nicely! I mainly prefer [MSDN's guidelines][1], but not their overusage of **var**. Basically if it is clean I will be OK with it. Use camel-case, capitilize the first letter of classes, namespaces, methods, etc. Don't capitalize the first letter of variables. Private variables should be indicated by a leading underscore (i.e. _iAmPrivate). Method names should be descriptive. I could go on, but hopefully you all get the point. 


#### Updating your Pull Request

Sometimes, you will asked you to edit your Pull Request before it is included. This is normally due to spelling errors or because your request didn't match these guidelines.

[Here](https://github.com/RichardLitt/docs/blob/master/amending-a-commit-guide.md) is a write up on how to change a Pull Request, and the different ways you can do that.


[1]:https://msdn.microsoft.com/en-us/library/ff926074.aspx?f=255&MSPPError=-2147217396