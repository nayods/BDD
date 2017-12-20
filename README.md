# BDD framework for testing applications in Csharp using Specflow and celenium and webdriver and nunit
TABLE OF CONTENT requirement for the testing framwork

1. Feature File 
2. Step Definition
3. Tags 
4. Background
5. Scenario Outline 
6. Tables
7. Hooks 
8. Scoped Bindings 
9. Feature Context 
10 Scenario Context 
11 Step Context 
12 Test error 
13 Reading Log file

1. Feature File
This is the file that holds our BDD test cases written in gherkin syntax. 

2. Step Definition
This is the file which binds our automation code to the gherkin syntax written in the feature file. 

3.Tags 
This are attributes added inside a feature file to filter it it can be added to a specific  scenario or an entire feature eg. @mytag

4.Background
This a piece of logic that runs before each feature is executed and it located inside a feature file and its code logic is located inside a step definition file.

5. Scenario Outline 
This is a type of scenario where multiple data is passed via a table and one of its distinct characteristics is it has another keyword called Example. This is used for driving testing. this is located in the feature file 

6. Table 
This is a spec flow mechanism for passing data is has a similar principle to scenario outline, this is also located in a feature file. 

7 Hooks 
This are attributes that are called at specific times in the life cycle of the application 
and what we do is create a hookes class and call all the hooks inside it, its best practice to keep all hooks in a separate class 

8 scoped Bindings 
This is when we create a specific hooke for a specific feature or a specific scenario 
what this means is we can have 2 or more of the same type of hooks inside our hooks class 
and we can make run and stop the other from running by scoping it with a tag similar to the tags mentioned above. 

9 Feature Context 
This a property that holds details of the current feature running its the same with the scenario context and step context and this important because we can use this for error handling and reporting. 

10 Test Error
By checking the error property in the scenario context we can check if there is an error and if there is then we can print out the scenario name producing the error and keep a log of it. 

11 Reading log file 
This is just how to understand how the log files is printed to avoid confusion 




