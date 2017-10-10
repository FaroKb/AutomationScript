using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MainScript
{
    class APIKeys {

        public static String EnKey = "52619be1e1e0733a00a2d630e3d61e2a2ee053e77ac98a9246a009ec52e5c5dc";
        public static String EnSecret = "eef7967326032dc945b2a4ea65f3176b758ec732598701a136976ef459917308";

        public static String DevKey = "0d8609955a877e19b0e6785b599ac107f157e9f8518d86ca685ad47dcb31bbcf";
        public static String DevSecret = "1fff5ef16b012e3c7d385bfb6f8637f9b03b4b6ff347b83db7dd9c71bf378f78";

        public static String JaKey = "82e7c173b8c7c205dc49232239520fe0f20a38b4f5659590939737ceb9f3b6c4";
        public static String JaSecret = "eb72d022a3e1201bd616dccd0666baa6b3c14e15a3e2752fb43c1916be6d9f82";

        public static String DeKey = "9d3fe8e1654e83260090b59966158cb2e3ea4ac24c332dcff6b8b97017173535";
        public static String DeSecret = "dbcba7985a90f4c350f7bf0c0265b1c2bee1ea0d49e2d244597288cdb1dab9fa";

        public static String ZhKey = "90cb6c6f5477da24284a9a6a1a70e30b5a67f3f3f69e2eda4eda1d6ddc80e176";
        public static String ZhSecret = "6fe0fcc4931416f453144f53806fdd8bbc0d9f845e6e2a8cdf492d554aa413d2";

        public static String EsKey = "72dd5b19e5fb119bd00d63fc8fcc0f77a6b9b5985c65a478cd9b79ee2d464eef";
        public static String EsSecret = "d27cccd55415a775468b49b24440e994bf04479bbb706efce1f1986706b426b8";

        public static String ItKey = "6b241b779c976697428f49dbe3b9e5501220bb4a51ff725b325c029d436df0e3";
        public static String ItSecret = "c5ff83d8af086b8cb79d924c021f762c8048aac3352a10c0ad0891a3cdebf84f";

        public static String FrKey = "201ead2d5dcbd0f553fb5939d4c4089d913e277595c2ac649125f1a30d6f82b5";
        public static String FrSecret = "bc9b06b2f074c46a6e34f310988c6081865535460a407cbba640d33617a7087f";

        public static String PtKey = "3af6cbdb2ec93dc473d8e902c5d968b5eceb2d5f329c323630c360f4ed4fa417";
        public static String PtSecret = "f48ef7cc920a028082e263ee5b8775383b85d65782bd594123dfe44f391da7df";

        public static String GenerateTokenEn()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(EnSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(EnKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", EnKey, epoch, hash);

            return token;
        }

        public static String GenerateTokenDev()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(DevSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(DevKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", DevKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenJa()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(JaSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(JaKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", JaKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenDe()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(DeSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(DeKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", DeKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenZh()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(ZhSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(ZhKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", ZhKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenEs()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(EsSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(EsKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", EsKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenIt()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(ItSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(ItKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", ItKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenFr()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(FrSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(FrKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", FrKey, epoch, hash);

            return token;
        }
        public static String GenerateTokenPt()
        {
            var hash = "";
            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(PtSecret)))
            {
                var bytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(PtKey + epoch));
                hash = BitConverter.ToString(bytes).Replace("-", "");
            }
            var token = string.Format("{0}_{1}_{2}", PtKey, epoch, hash);

            return token;
        }
   }

}
