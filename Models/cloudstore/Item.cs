using Google.Cloud.Firestore;
using dumplingsOrderBackend.Interfaces;

namespace dumplingsOrderBackend.Models
{
    [FirestoreData]
    public class Item: IBaseDto
    {
        public string id {get; set;}

        [FirestoreProperty]
        public string name { get; set; }

        [FirestoreProperty]
        public int unit { get; set; }

        [FirestoreProperty("price")]
        public int price { get; set;  }

        [FirestoreProperty]
        public bool isDelete { get; set; }

        [FirestoreProperty]
        public string memo { get; set; }

        [FirestoreProperty]
        public Timestamp updatedTime { get; set; }
    }
}