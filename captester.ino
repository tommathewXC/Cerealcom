int led = 13;
int in_pin = A0;
int val = 0;
int counte = 0;
void setup()
{
  pinMode(led,OUTPUT);
  pinMode(in_pin,INPUT);
  Serial.begin(9600);
  
}

void loop()
{
  while(counte <= 7000)
  { 
    
    while(counte ==0)
    {delay(9000);
     digitalWrite(led, HIGH);
      counte++;
     }
     
    val = int(analogRead(in_pin));
    Serial.println(val,DEC);
    counte++;
   }
}

