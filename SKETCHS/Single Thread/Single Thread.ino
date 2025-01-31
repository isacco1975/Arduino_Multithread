String serialValue = "";
String serialCmd = "";
String numSecs = "";

void setup() {
  pinMode(2, OUTPUT); //BLUE LED
  pinMode(4, OUTPUT); //GREEN LED
  pinMode(6, OUTPUT); //BUZZER

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
       digitalWrite(2, HIGH);     
    }
    if (serialCmd == "2")
    {
       digitalWrite(4, HIGH);     
    }
    if (serialCmd == "3")
    {
       tone(6, 500);     
    }
 
    delay(numSecs.toInt() * 1000);
  }

  digitalWrite(2, LOW);
  digitalWrite(4, LOW);
  noTone(6);
}
