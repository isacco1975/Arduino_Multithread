unsigned long startTime1;
unsigned long startTime2;
unsigned long startTime3;
String serialValue = "";
String serialCmd = "";
String numSecs = "";
int interval1 = 0;
int interval2 = 0;
int interval3 = 0;
int taskNumber1 = 0;
int taskNumber2 = 0;
int taskNumber3 = 0;
int taskNumber = 0;

void setup() {
   pinMode(2, OUTPUT); //GREEN LED ID 1
   pinMode(4, OUTPUT); //BLUE LED  ID 2
   pinMode(6, OUTPUT); //BUZZER    ID 3

   Serial.begin(9600,SERIAL_8N1); // opens serial port, sets data rate to 9600 bps
}

void loop() {
   if (Serial.available())
   {
      serialValue = Serial.readString();
      serialCmd = serialValue.substring(0, 1); //X;NN X=1,2,3 NN=00
      numSecs = serialValue.substring(4,2);

      if (taskNumber >= 32767)
         taskNumber = 0;

      taskNumber++;

      if (serialCmd == "1")
      {
         startTime1 = millis();
         interval1 = numSecs.toInt() * 1000;

         if (taskNumber1 >= 32767)
           taskNumber1 = 0;

         taskNumber1 = taskNumber1 + taskNumber;

         Serial.print("STARTED TASK: ");
         Serial.print(taskNumber1);
         Serial.println(" - Device 1 ");
      }

      if (serialCmd == "2")
      {
         startTime2 = millis();
         interval2 = numSecs.toInt() * 1000;

         if (taskNumber2 >= 32767)
           taskNumber2 = 0;

         taskNumber2 = taskNumber2 + taskNumber;;

         Serial.print("STARTED TASK: ");
         Serial.print(taskNumber2);
         Serial.println(" - Device 2 ");
      }

      if (serialCmd == "3")
      {
         startTime3 = millis();
         interval3 = numSecs.toInt() * 1000;

         if (taskNumber3 >= 32767)
           taskNumber3 = 0;

         taskNumber3 = taskNumber3 + taskNumber;;

         Serial.print("STARTED TASK: ");
         Serial.print(taskNumber3);
         Serial.println(" - Device 3 ");
       }
    }

    StartThreads();
}

void StartThreads()
{
   thread_GreenLed(interval1);
   thread_BlueLed(interval2);
   thread_Buzzer(interval3);
}

void thread_GreenLed(int interval)
{
   if (interval > 0)
      digitalWrite(2, HIGH);

   unsigned long currentTime = millis();
   unsigned long elapsedTime = currentTime - startTime1;

   if ((elapsedTime > interval) && interval > 0)
   {
      digitalWrite(2, LOW);
      Serial.print("TASK [");
      Serial.print(taskNumber1);
      Serial.print("] Finished: Elapsed time: ");
      Serial.println(elapsedTime -1);
      startTime1 = 0;
      interval1 = 0;
      interval = 0;
      taskNumber1 = 0;
   }
}

void thread_BlueLed(int interval)
{
   if (interval > 0)
      digitalWrite(4, HIGH);

   unsigned long currentTime = millis();
   unsigned long elapsedTime = currentTime - startTime2;

   if ((elapsedTime > interval) && interval > 0)
   {
      digitalWrite(4, LOW);
      Serial.print("TASK [");
      Serial.print(taskNumber2);
      Serial.print("] Finished: Elapsed time: ");
      Serial.println(elapsedTime -1);
      startTime2 = 0;
      interval2 = 0;
      interval = 0;
      taskNumber2 = 0;
   }
}

void thread_Buzzer(int interval)
{
   if (interval > 0)
      tone(6, 500);

   unsigned long currentTime = millis();
   unsigned long elapsedTime = currentTime - startTime3;

   if ((elapsedTime > interval) && interval > 0)
   {
       noTone(6);
       Serial.print("TASK [");
       Serial.print(taskNumber3);
       Serial.print("] Finished: Elapsed time: ");
       Serial.println(elapsedTime -1);
       startTime3 = 0;
       interval3 = 0;
       interval = 0;
       taskNumber3 = 0;
   }
}
