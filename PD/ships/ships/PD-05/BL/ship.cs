using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD_05.BL
{
    class ship
    {
        public string shipno;
        angle latitude = new angle();
        angle longitude = new angle();
        public void shiplatitude(int deg, float min, char dir)
        {
            latitude.degree = deg;
            latitude.direction = dir;
            latitude.minute = min;
        }
        public ship()
        {

        }
        public void shiplongitude(int deg, float min, char dir)
        {
            longitude.degree = deg;
            longitude.direction = dir;
            longitude.minute = min;
        }
        public ship(string shipno)
        {
            this.shipno = shipno;
        }
        public int shipposition(List<ship> shipsdata, string name)
        {
            int serialnumber = 0;
            for(int x=0; x<shipsdata.Count;x++ )
            {
                if(shipsdata[x].shipno == name)
                {
                    serialnumber = x;
                }
            }
            return serialnumber; 
        }
        public void latitudevalue(ref int deg, ref float min, ref char dir)
        {
             deg = latitude.degree;
             min= latitude.minute ;
             dir = latitude.direction;
        }
        public void longitudevalue(ref int deg, ref float min, ref char dire)
        {
            deg = longitude.degree;
             min = longitude.minute;
             dire = longitude.direction ;
        }
        public void shipserialnumber( string longitudecoordinates, string latitudecoordinates, ref int latitudedegree, ref float latitudeminute, ref char latitudedirection, ref int longitudedegree, ref float longitudeminute, ref char longitudedirection)
        {
             
            int degsign = 0;
            int minsign = 0;
            string data = ""; //   for data conversion
            for(int x=0;x < longitudecoordinates.Count();x++)
            {
                if(longitudecoordinates[x] == '>')
                {
                    degsign = x;
              
                }
                if(longitudecoordinates[x] == '<')
                {
                    minsign = x;
                
                }
            }
            for (int y = 0; y < degsign; y++)
            {
                data = data + longitudecoordinates[y];
            }

            longitudedegree = int.Parse(data);
            data = "";
            for(int z=degsign+1;z<minsign;z++)
            {
                data = data + longitudecoordinates[z];
            }

            longitudeminute = int.Parse(data);
            longitudedirection = (longitudecoordinates[longitudecoordinates.Count() - 1]);

            degsign = 0;
            minsign = 0;
            data = "";
            for (int x = 0; x < latitudecoordinates.Count(); x++)
            {
                if (latitudecoordinates[x] == '>')
                {
                    degsign = x;
            
                }
                if (latitudecoordinates[x] == '<')
                {
                    minsign = x;
                }
            }
            for (int y = 0; y < degsign; y++)
            {
                data = data + latitudecoordinates[y];
            }
            latitudedegree = int.Parse(data);
            data = "";
            for (int z = degsign + 1; z < minsign; z++)
            {
                data = data + latitudecoordinates[z];
            }
            latitudeminute = int.Parse(data);
            latitudedirection = (latitudecoordinates[latitudecoordinates.Count() - 1]);
            
        }
        public bool valueReturn( ref int latitudedegree, ref float latitudeminute, ref char latitudedirection, ref int longitudedegree, ref float longitudeminute, ref char longitudedirection)
        {
            bool index = false;
            if((latitude.degree== latitudedegree) &&(latitude.minute == latitudeminute) && (latitude.direction == latitudedirection) && (longitude.direction == longitudedirection) && (longitude.minute == longitudeminute) && (longitude.direction == longitudedirection))
            {
                index = true;
            }
            return index;
        }

    }
    class angle
    {
        public int degree;
        public float minute;
        public char direction;
    }


}
