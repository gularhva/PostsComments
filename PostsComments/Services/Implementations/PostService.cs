using AutoMapper;
using PostsComments.Data.Entities;
using PostsComments.DTO;
using PostsComments.Services.Abstractions;

namespace PostsComments.Services.Implementations
{
    public class PostService:IPostService
    {
        private readonly IMapper _mapper;
        //private readonly IPostRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            //_repository = repository;
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<IEnumerable<Post>> Get()
        {
            ResponseModel<IEnumerable<Post>> rm = new ResponseModel<IEnumerable<Post>>();
            try
            {
                //rm.Data = _repository.GetAll();
                rm.Data = _unitOfWork.PostR.GetAll();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Post> Post(PostDTO model)
        {
            ResponseModel<Post> rm = new ResponseModel<Post>();
            try
            {
                Post post = _mapper.Map<Post>(model);
                rm.Data = post;
                //_repository.Add(Post);
                //_repository.Save();
                _unitOfWork.PostR.Add(post);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Post> Delete(int id)
        {
            ResponseModel<Post> rm = new ResponseModel<Post>();
            try
            {
                var data = _unitOfWork.PostR.GetById(id);
                //_repository.Delete(data);
                _unitOfWork.PostR.Delete(data);
                rm.Data = data;
                //_repository.Save();
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Post> Update(int id, PostDTO model)
        {
            ResponseModel<Post> rm = new ResponseModel<Post>();
            try
            {
                var data = _unitOfWork.PostR.GetById(id);
                _mapper.Map<PostDTO, Post>(model, data);
                //_repository.Update(data);
                _unitOfWork.PostR.Update(data);
                rm.Data = data;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }

        public Post GetById(int id)
        {
            var data = _unitOfWork.PostR.GetById(id);
            return data;
        }
    }
}
