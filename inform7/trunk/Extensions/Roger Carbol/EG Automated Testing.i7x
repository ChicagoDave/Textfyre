Version 1/090116 of EG Automated Testing (for Glulx only) by Roger Carbol begins here.

"Allows the author to create and run automated tests, which could be used for test-driven development."

Include Text Capture by Eric Eve.
Include Glulx Text Effects by Emily Short.

Book of Testing - not for release

Part 1 -- Things the User May Want to Change

[The following tables made possible by Glulx Text Effects by Emily Short.]

Table of User Styles (continued)
style name	justification	obliquity	indentation	first-line indentation	boldness	fixed width	relative size	glulx color
special-style-1	left-justified	no-obliquity	0	0	regular-weight	proportional-font	0	g-green
special-style-2	left-justified	no-obliquity	0	0	bold-weight	proportional-font	0	g-dark-red

Table of Common Color Values (continued)
glulx color value	assigned number
g-pure-green	65280
g-pure-red	16711680
g-dark-red	11141120
g-green	32768

success sign translates into Unicode as 8729.
failure sign translates into Unicode as 35.

Part 2 -- Defining Tests

A test is a kind of thing. 
  A test has a number called the index.
  A test has a table-name called steps.


Part 3 -- Defining the Testcontroller

Testcontroller is a thing.
  Testcontroller can be active.  Testcontroller is not active.  [When the tests are running, it is active.]
  Testcontroller can be stable or unstable.  Testcontroller is stable. [If we never reach our handle test  response rule, something is wrong and we are unstable. ]
  Testcontroller has a text called testname.  [The name of the test object we're currently running.]
  Testcontroller has a text called command.  [The command we're feeding to the parser.]
  Testcontroller has a text called tc_response.  [The regular expression we expect the output to match.]
  Testcontroller has a table-name called underway.  [The name of the table of steps that belongs to the  current test object.]
  Testcontroller has a number called total-steps.  [Number of rows in the underway table.]
  Testcontroller has a number called current-step.  [The row in the underway table we're on.]
  Testcontroller has a number called index.  [Index to the test item currently executing]


Part 4 -- Defining the Asserting and Test-Stopping

Understand "assert [any things]" as asserting.

Asserting is an action out of world and applying to one thing.

Check asserting:
  if the noun is not a test, say "Testing Error:  Tried to assert [noun] but that is not a test object."  instead.

Carry out asserting:
  now testcontroller is active;
  now underway of testcontroller is the steps of the noun;
  now testname of testcontroller is the printed name of the noun;
  choose row 1 in underway of testcontroller;
  now the command of testcontroller is the command entry;
  now the tc_response of testcontroller is the response entry;
  now the total-steps of testcontroller is the number of rows in
  the underway of testcontroller;
  now the current-step of testcontroller is 1;
  start timer.


Understand "assert all" as allasserting.
Allasserting is an action out of world and applying to nothing.

Check allasserting:
  if Table of Scripts is empty, say "The Table of Scripts is empty!" instead.

Carry out allasserting:
  write File of Scripts from the Table of Scripts;
  reboot.


Understand "stop the test" as teststopping.

Teststopping is an action out of world and applying to nothing.

Check teststopping:
  if testcontroller is not active, say "You're not testing right now!"  instead.

Carry out teststopping:
  stop the test.

Report teststopping:
  say "[line break]All tests stopped."


To stop the test:
	stop timer;
	now testcontroller is not active;
	if the Table of Executions is not empty:
		repeat through the Table of Executions:
			blank out the whole row;
		write File of Scripts from the Table of Executions;
	if the Table of Reports is not empty:
		repeat through the Table of Reports:
			blank out the whole row;
		write File of Reports from the Table of Reports;


Part 5 -- Specifying Files and Tables

The File of Scripts (owned by another project) is called "scripts".
The File of Reports (owned by another project) is called "reports".

Table of Scripts
Index
a number

Table of Executions
Index
a number
with 1000 blank rows

Table of Reports
Index	Step	Result
a number	a number	a number
with 1000 blank rows


Part 6 -- When Play Begins

When play begins:
	if File of Reports exists:
		read File of Reports into Table of Reports;
	if File of Scripts exists:
		read File of Scripts into the Table of Executions;
	if the Table of Executions is not empty:
		repeat through the Table of Executions:
			repeat with item running through tests:
				if the index of the item is the index entry:
					now index of testcontroller is the index entry;
		repeat through the Table of Executions:
			if index of testcontroller is the index entry:
				blank out the whole row;
		write File of Scripts from the Table of Executions;
		repeat with item running through tests:
			if the index of the item is the index of testcontroller:
				try asserting the item;
	otherwise:
		if the Table of Reports is not empty:
			issue report;
			repeat through the Table of Reports:
				blank out the whole row;
			write File of Reports from the Table of Reports.


Part 7 -- The Turn Sequence Rule

This is the handle test response rule:
	if testcontroller is active:
		now testcontroller is stable;
		stop capturing text;
		say "[line break][captured text]";
		let captext be text;
		change captext to "[captured text]";
		if captext matches the regular expression the tc_response of testcontroller:
			say "[first custom style][unicode success sign] success: [index of testcontroller]  [testname of testcontroller], step [current-step of testcontroller][roman type] -- matched '[tc_response of testcontroller]'[line break]";		
			choose a blank row in Table of Reports;
			change index entry to index of testcontroller;
			change step entry to current-step of testcontroller;
			change result entry to 0;
			write File of Reports from the Table of Reports;
		otherwise:
			say "[second custom style][unicode failure sign] FAIL: [index of testcontroller]  [testname of testcontroller], step [current-step of testcontroller][roman type] -- did not match '[tc_response of testcontroller]'[line break]";
			choose a blank row in Table of Reports;
			change index entry to index of testcontroller;
			change step entry to current-step of testcontroller;
			change result entry to 1;
			write File of Reports from the Table of Reports;
		if the current-step of testcontroller is the total-steps of testcontroller:
			reboot;
		otherwise:
			increase the current-step of testcontroller by 1;
			choose row the current-step of testcontroller in underway of testcontroller;
			now the command of testcontroller is the command entry;
			now the tc_response of testcontroller is the response entry.

 
The handle test response rule is listed last in the turn sequence rules.


Part 8 -- Reporting the Results

To issue report:
	repeat through the Table of Reports:
		if result entry is 0, say "[first custom style][unicode success sign] success: ";
		if result entry is 1, say "[second custom style][unicode failure sign] FAIL: ";
		repeat with item running through tests:
			if the index of the item is the index entry:
				say "[index entry] [item], step [step entry][line break][roman type]".


Part 9 -- The Magical Glulx Stuff

Include (-

#ifndef TIMER_DELAY;
Constant TIMER_DELAY 10;
#endif;

  [ HandleGlkEvent ev context abortres newcmd cmdlen  ;
      context = 0; ! suppress ignored warning
      switch (ev-->0) {
	evtype_Timer:
		FollowRulebook( (+glulx timed activity rules+) );
		if ( FollowRulebook( (+command-counting rules +) ) && RulebookSucceeded())
		{
			FollowRulebook( (+command-showing rules+) );
			if ( FollowRulebook( (+command-pasting rules+) ))  return 2;
		}
	}
   ];

-) before "Glulx.i6t".

Glulx replacement command is some indexed text that varies.

The glulx timed activity rules is a rulebook.
A glulx timed activity rule (this is the default command replacement by timer rule): 
	if testcontroller is unstable:
		say "[line break][line break][second custom style][unicode failure sign] ABORT: [index of  testcontroller] [testname of testcontroller], step [current-step of testcontroller][roman type] -- Things have  gone horribly wrong.  It is likely the parser did not recognize one or more words in your command.[line  break]";
		stop the test;
	change the glulx replacement command to command of testcontroller;
	now testcontroller is unstable;
	rule succeeds.

The command-counting rules are a rulebook.
A command-counting rule (this is the ordinary checking for content rule):
	if the number of characters in the glulx replacement command is 0, rule fails;
	rule succeeds.

The command-showing rules are a rulebook.
A command-showing rule (this is the print text to the input prompt rule):
	say input-style-for-glulx;
	say Glulx replacement command;
	say roman type;
	start capturing text.

To say input-style-for-Glulx:
	(- glk_set_style(style_Input); -)

The command-pasting rules are a rulebook.
A command-pasting rule (this is the glue replacement command into parse buffer rule):
	change the text of the player's command to the Glulx replacement command;
	rule succeeds.

Use timer delay of at least 10 translates as (- Constant TIMER_DELAY = {N}; -).

Include (-
 [ StartTimer msec ;
 glk_request_timer_events(msec);
 ]; -)

To start timer: (-
StartTimer(TIMER_DELAY); -)

To stop timer: (-
StartTimer(0); -)

[I suspect this is a horrible hack; sorry.]
To reboot: (- glk_request_timer_events(0); GL__M(##Restart, 1);
@restart; GL__M(##Restart, 2); -).

EG Automated Testing ends here.

---- DOCUMENTATION ----

Automated Testing allows the author to create and run automated tests, which could be used for test-driven development.

Chapter: Introduction

Section: Introduction

Automated Testing allows the author to create and run automated tests.

The test scripts are stored as rows of tables that belong to test objects.  These scripts specify a number of parser commands, such as "examine me", and the corresponding response expected from the game, such as "As good-looking as ever."

They are automated in that the author can quickly execute all defined test scripts and receive a report on which passed and which failed.  The virtual machine is restarted between tests.

This sort of automated testing could be used for test-driven development, but this functionality should be useful to any author.  In any case, the topic is somewhat beyond the scope of this document.

Chapter: Tests

Section: Test Objects

Tests have the following definition:

	A test is a kind of thing. 
		A test has a number called the index.
		A test has a table-name called steps.


The following is an example of a test object:

	Verify Player Description is a test.
		The index of Verify Player Description is 1.
		The steps of Verify Player Description is the Table of Steps for Verify Player Description.

The index of a test identifies it and should be unique.  The indexes of the tests to be run are listed in Table of Scripts.

The steps of a test is the name of the table which contains the various commands which compose its script.

Section: Test Tables

A test's "steps" table has the form:

	Table <name>
	order	command	response
	a number	text	text

The following is an example of a test table:

	Table of Steps for Verify Player Description
	order	command	response
	1	"examine me"	"^As good\-looking as ever\.\n\n$"
	2	"x myself"	"^As good\-looking as ever\.\n\n$"

The order is a number that keeps the steps running in sequential order.

The command is the text that the player would type in.

The response is a regular expression that should match the game's response.

Section: Table of Scripts

In order to execute a script with "assert all", its index needs to be in the Table of Scripts.  This table is defined as:

	Table of Scripts
	Index
	a number

and is initially empty.  To add your scripts, add code such as:

	Table of Scripts (continued)
	Index
	3
	2
	1

Note that the scripts are executed in bottom-to-top order.

Section: Asserting

The command to run every test that is defined is:

	>assert all

It is occasionally useful to run individual tests with:

	>assert <name of test>

For example,

	>assert Verify Player Description

Section: Stopping the Test

When a test failure occurs, it is sometimes useful to stop the test execution at the point of failure.  The command for this is:

	stop the test

As demonstrated in:

	Table of Steps for Verify Player Description
	order	command	response
	1	"examine me"	"^As good\-looking as ever\.\n\n$"
	2	"x myself"	"^More good\-looking than ever\.\n\n$"
	3	"stop the test"	".*"

Section: Slowing the Tests

By default, the tests execute quickly.  However, it is occasionally useful or interesting to slow down the process.  This is done with:

	Use timer delay of at least <X>.

where <X> is the number of milliseconds between commands.  For example,

	Use timer delay of at least 5000.

will execute one command once every 5 seconds, more or less.

Chapter: Known Limitations

Section: Out of World Problems

This extension does not handle actions that are out-of-world very gracefully.  In general, if the player enters something that doesn't advance the turn counter, there will probably be problems.  Examples of problematic commands include:

	>score
	>undo
	>finagle the scallywag

(where the last example contains words not understood by the parser.)

Chapter: FAQ

Section: How Do I...

Questions and answers to follow.

Section: Common Problems and How to Fix Them

Questions and answers to follow.


Example: * Testing the Waters 1 - Some basic tests.

	*: "Testing the Waters 1"

	Include Automated Testing by Roger Carbol.

	Use timer delay of at least 100.
	Use maximum capture buffer length of at least 1024.

	Chapter 1 - The Game

	The Cabin is a room. "The front of the small cabin is entirely occupied with navigational instruments, a radar display, and radios for calling back to shore. Along each side runs a bench with faded blue vinyl cushions, which can be lifted to reveal the storage space underneath. A glass case against the wall contains several fishing rods. 

Scratched windows offer a view of the surrounding bay, and there is a door south to the deck. A sign taped to one wall announces the menu of tours offered by the Yakutat Charter Boat Company." 

	The Cabin contains a glass case. In the glass case is a collection of fishing rods. 

	The case is closed, transparent, and openable. 

	The bench is in the cabin. On the bench are some blue vinyl cushions. 

	The bench is enterable. 

	Chapter 2 - The Tests - Not for release 

	Table of Scripts (continued)
	Index
	3
	2
	1

	Verify Player Description is a test.
		The index of Verify Player Description is 1.
		The steps of Verify Player Description is the Table of Steps for Verify Player Description.

	Table of Steps for Verify Player Description
	order	command	response
	1	"examine me"	"^As good\-looking as ever\.\n\n$"
	2	"x myself"	"^As good\-looking as ever\.\n\n$"

	Verify Cabin Description is a test.
		The index of Verify Cabin Description is 2.
		The steps of Verify Cabin Description is the Table of Steps for Verify Cabin Description.

	Table of Steps for Verify Cabin Description
	order	command	response
	1	"l"	"^Cabin\nThe front of the small cabin is entirely occupied with navigational instruments, a radar display, and radios for calling back to shore\. Along each side runs a bench with faded blue vinyl cushions, which can be lifted to reveal the storage space underneath\. A glass case against the wall contains several fishing rods\.\n\nScratched windows offer a view of the surrounding bay, and there is a door south to the deck\. A sign taped to one wall announces the menu of tours offered by the Yakutat Charter Boat Company\.\n\nYou can see a glass case \(closed\) \(in which is a collection of fishing rods\) and a bench \(on which are some blue vinyl cushions\) here\.\n\n$"
	
	Verify Rods-and-Case is a test.
		The index of Verify Rods-and-Case is 3.
		The steps of Verify Rods-and-Case is the Table of Steps for Verify Rods-and-Case.

	Table of Steps for Verify Rods-and-Case
	order	command	response
	1	"take rods"	"^The glass case isn't open\.\n\n$"
	2	"open case"	"^You open the glass case\.\n\n$"
	3	"take rods"	"^Taken\.\n\n$"
	4	"i"		"^You are carrying:.*a collection of fishing rods\n\n$"


	test me with "assert all"

Example: ** Testing the Waters 2 - Demonstrating a failed test.

	*: "Testing the Waters 2"

	Include Automated Testing by Roger Carbol.

	Use timer delay of at least 100.

	Chapter 1 - The Game

	The Cabin is a room. "The front of the small cabin is entirely occupied with navigational instruments, a radar display, and radios for calling back to shore. Along each side runs a bench with faded blue vinyl cushions, which can be lifted to reveal the storage space underneath. A glass case against the wall contains several fishing rods.Scratched windows offer a view of the surrounding bay, and there is a door south to the deck. A sign taped to one wall announces the menu of tours offered by the Yakutat Charter Boat Company."

	The Cabin contains a glass case. In the glass case is a collection of fishing rods.

	[I mistakenly assume that containers are closed by default...]

	The case is transparent, and openable.
	[The case is closed.]


	The bench is in the cabin. On the bench are some blue vinyl cushions.

	The bench is enterable.

	Chapter 2 - The Tests - Not for release

	Table of Scripts (continued)
	Index
	2
	1

	Verify Player Description is a test.
		The index of Verify Player Description is 1.
		The steps of Verify Player Description is the Table of Steps for Verify Player Description.

	Table of Steps for Verify Player Description
	order	command	response
	1	"examine me"	"^As good\-looking as ever\.\n\n$"
	2	"x myself"	"^As good\-looking as ever\.\n\n$"

	Verify Rods-and-Case is a test.
		The index of Verify Rods-and-Case is 2.
		The steps of Verify Rods-and-Case is the Table of Steps for Verify Rods-and-Case.

	Table of Steps for Verify Rods-and-Case
	order	command	response
	1	"take rods"	"^The glass case isn't open\.\n\n$"
	2	"stop the test"	".*"
	[
	2	"open case"	"^You open the glass case\.\n\n$"
	3	"take rods"	"^Taken\.\n\n$"
	4	"i"	"^You are carrying:.*a collection of fishing rods\n\n$"
	]

	[I've commented out the steps after the failure and added a "stop the test" to take a closer look.]


	test me with "assert all"

	test case with "assert Verify Rods-and-Case"
