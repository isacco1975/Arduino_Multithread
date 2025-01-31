unsigned long startTime1;
unsigned long startTime2;
unsigned long startTime3;
String serialValue = "";
String serialCmd = "";
String numSecs = "";
int interval1 = 0;
int interval2 = 0;
int interval3 = 0;

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
    
    if (serialCmd == "1")
    {
       startTime1 = millis();
       interval1 = numSecs.toInt() * 1000;
    }
    
    if (serialCmd == "2")
    {
       startTime2 = millis();
       interval2 = numSecs.toInt() * 1000;
    }

    if (serialCmd == "3")
    {
       startTime3 = millis();
       interval3 = numSecs.toInt() * 1000;
    }
  }

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

  if (elapsedTime > interval)
    digitalWrite(2, LOW);
  
  delay(10);       
}

void thread_BlueLed(int interval) 
{
  if (interval > 0)
    digitalWrite(4, HIGH);     
   
  unsigned long currentTime = millis();
  unsigned long elapsedTime = currentTime - startTime2;

  if (elapsedTime > interval)
    digitalWrite(4, LOW);
  
  delay(10);       
}

void thread_Buzzer(int interval) 
{
  if (interval > 0)
    tone(6, 500);     
   
  unsigned long currentTime = millis();
  unsigned long elapsedTime = currentTime - startTime3;

  if (elapsedTime > interval)
    noTone(6);
  
  delay(10);       
}
