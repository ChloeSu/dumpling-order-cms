using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using dumplingsOrderBackend.Interfaces;
using Google.Cloud.Firestore;

namespace dumplingsOrderBackend.Repositories
{
    // base for cloud store
    public class BaseRepository<TDto, TCloudStore>: IBaseRepository<TDto, TCloudStore>
    {
        public BaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task DeleteAsync(string key)
        {
            await _db.Collection(collectionName).Document(key).DeleteAsync();
        }
        public async Task AddAsync(TDto item)
        {
            await _db.Collection(collectionName).AddAsync(_mapper.Map<TCloudStore>(item));
        }

        public async Task UpdateAsync(TDto item)
        {
            await _db.Collection(collectionName).Document(((IBaseDto)item).id).SetAsync(_mapper.Map<TCloudStore>(item));
        }
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            Query query = _db.Collection(collectionName);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            return querySnapshot
                    .Where(x => x.TryGetValue<bool>("isDelete",out bool isDelete) && !isDelete)
                    .Select(x => _mapper.Map<TDto>(x)).ToList();
        }
        public async Task<TDto> GetByIdAsync(string key)
        {
            DocumentReference docRef = _db.Collection(collectionName).Document(key);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            return _mapper.Map<TDto>(snapshot);
        }

        public async Task<string> GetSeedId()
        {
            // await _locker.WaitAsync();
            // DocumentReference docRef = _db.Collection(Constants.SEED).Document(collectionName);
            // DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            // Dictionary<string, object> obj = snapshot.ToDictionary();
            // int result = (int)(long)obj["id"];
            // obj["id"] = result + 1;
            // await docRef.SetAsync(obj);
            // _locker.Release();

            DocumentReference docRef = _db.Collection(Constants.SEED).Document(collectionName);
            return await _db.RunTransactionAsync(async transaction =>
            {
                DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(docRef);
                int result = (int)snapshot.GetValue<long>("id");
                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "id", result+1 }
                };
                transaction.Update(docRef, updates);
                return result.ToString();
            });
        }

        protected FirestoreDb _db = FirestoreDb.Create(Constants.PROJECT_ID);
        protected string collectionName = "";
        // private static readonly SemaphoreSlim _locker = new SemaphoreSlim(1);
        private IMapper _mapper;
        private object res;
    }
}