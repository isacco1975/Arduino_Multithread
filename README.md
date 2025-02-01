This is a sample controlling Arduino Nano via Simple Emails.

It's possible to control more devices at once by sending many messages to the attached SMTP Server written in VB at once.
Here there are 2 sketchs: one single threaded, that needs to wait the number of seconds passed, and one that can run more executions at once. 

example: Asking arduino to turn on the blue led for 10 seconds, and while is executing this command, sending from the client another message to turn on the green led for 30 seconds.

