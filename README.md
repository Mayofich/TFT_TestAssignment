# TFT_TestAssignment
Test assignment for a job interview, the test is senior level and won't be solved in full scope since I am not at that level, I will do my best to solve as much of the assignment as I can in the time given. I have been given 7 days (5 work days) and am doing it along my current job and family responsibilities.

NOTE 1 START
How many tables do I need for the database?
What entities should have their own table for easier changes in the database as the time progresses if the client has additional expectations, how to make the database easier to adjust for later management?
Director should be their own table (class) it should have an Id(login name? unique key), Name, Surname, password, the table does not need to have movie section or any additional info connected to the table directly, this search may be done through the SQL query including Film(invitation…) table to get connected movies invitations etc. 
Actor should also be a separate table and again as the Director should only have personal info connected inside the table while other values should be externally linked through the ID

Given that I have several things here that are multilinked, I wonder if it is better to put a string inside a table or several tables, for example: one genre has several movies and one movie has several genres, is it better that the field genre with the id of the genre in the movie be array element that I extract or is it better to have a separate link table, with actor/film the request table is obviously needed, it is additional, then it has the accepted/not accepted element in it, however, for the film/genre, is a separate table needed for that, it is possible that again it's because of the search by genre.
Conclusion being I need separate tables for each entity including Invitations and Genre connections?

After reading this link Entity Framework Core Code First - Basic and Custom Migrations for PostgreSQL (craftedpod.com) I think all of this can be sorted through navigation properties? (which by my understanding create connections between data parts without storing additional data?) 

So technically by using ICollection I’ll be sparing myself the trouble of the actual thinking of the exact database structure (which is what I was trying to get here)

NOTE 1 END

NOTE 2 START

Created tables in database through dependency injection, now need to create CRUD through it, had some issues with code changes from older examples I followed to the version of .net and EF I am using for the project.
Currently unsure if the relations between table parts are working as expected which will be checked at some point.
I will first start with managing CRUD operations as if the user of the database is admin, then I will try to add user control if able

NOTE 2 END


NOTE 3 START

Stopped writing notes... UPS... Couldn't work on the project during the weekend, did my best to get as far as I can on Monday before the deadline.
I am not satisfied with the progress I made I think I lost a lot of time trying stuff out and didn't write code that is functional enough.
My main issue is not being sure how to connect database pieces through code-first approach.

NOTE 3 END
