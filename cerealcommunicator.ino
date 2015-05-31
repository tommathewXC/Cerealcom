int in_pin = A0;
int val = 0;
void setup()
{
  pinMode(in_pin,INPUT);
  Serial.begin(9600);
  
}

void loop()
{
  //val = int(analogRead(in_pin));
  //Serial.println(val,DEC);
  //delay(100);
}

