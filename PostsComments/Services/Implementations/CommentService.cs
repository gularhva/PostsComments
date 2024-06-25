using AutoMapper;
using PostsComments.Data.Entities;
using PostsComments.DTO;
using PostsComments.Services.Abstractions;

namespace PostsComments.Services.Implementations
{
    public class CommentService:ICommentService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            //_repository = repository;
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<IEnumerable<Comment>> Get()
        {
            ResponseModel<IEnumerable<Comment>> rm = new ResponseModel<IEnumerable<Comment>>();
            try
            {
                //rm.Data = _repository.GetAll();
                rm.Data = _unitOfWork.CommentR.GetAll();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Comment> Post(CommentDTO model)
        {
            ResponseModel<Comment> rm = new ResponseModel<Comment>();
            try
            {
                Comment comment = _mapper.Map<Comment>(model);
                rm.Data = comment;
                //_repository.Add(Comment);
                //_repository.Save();
                _unitOfWork.CommentR.Add(comment);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Comment> Delete(int id)
        {
            ResponseModel<Comment> rm = new ResponseModel<Comment>();
            try
            {
                var data = _unitOfWork.CommentR.GetById(id);
                //_repository.Delete(data);
                _unitOfWork.CommentR.Delete(data);
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
        public ResponseModel<Comment> Update(int id, CommentDTO model)
        {
            ResponseModel<Comment> rm = new ResponseModel<Comment>();
            try
            {
                var data = _unitOfWork.CommentR.GetById(id);
                _mapper.Map<CommentDTO, Comment>(model, data);
                //_repository.Update(data);
                _unitOfWork.CommentR.Update(data);
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

        public Comment GetById(int id)
        {
            var data = _unitOfWork.CommentR.GetById(id);
            return data;
        }
    }
}
