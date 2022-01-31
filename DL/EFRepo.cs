using Models;
using Microsoft.EntityFrameworkCore;

namespace DL;

public class EFRepo : IRepo
{
    private DBContext _context;
    
    public EFRepo(DBContext context)
    {
        _context = context;
    }


    public List<Like> GetLikeByUserID(Like lk)
    {
        List<Like> likes = new List<Like> ();
        likes = _context.Likes.where(l => l.UserID = lk.UserID).ToList();
        return likes;
    }

    public List<Like> GetLikeByDrawingID(Like lk)
    {
        List<Like> likes = new List<Like> ();
        likes = _context.Likes.where(l => l.DrawingID = lk.DrawingID).ToList();
        return likes;
    }

    public List<Like> GetLikeByCommentID(Like lk)
    {
        List<Like> likes = new List<Like> ();
        likes = _context.Likes.where(l => l.CommentID = lk.CommentID).ToList();
        return likes;
    }

    public Like NewLike (Like lk)
    {
        Like like = new Like ();
        like = _context.Likes.Find.where(like => Likes.UserID = lk.UserID && Likes.DrawingID = lk.DrawingID && like.CommnetID = lk.CommentID);
        if (like == null)
        {
            like = _context.Likes.Add(lk);
        }
        return like;
    }

    public void RemoveLike (Like lk)
    {
        Like like = new Like ();
        like = _context.Likes.Find.where(like => Likes.UserID = lk.UserID && Likes.DrawingID = lk.DrawingID && like.CommnetID = lk.CommentID);
        if (like != null)
        {
            like = _context.Likes.Remove(lk);
        }
    }

    public List<Comment> GetCommentByDrawingID(Drawing draw)
    {
        List<Comment> comments = new List<Comment>();
        comments = _context.Comments.Find.where(c => c.DrawingID = draw.ID);
        return comments;
    }
}

    public Player AddNewPlayerAccount(Player playerToAdd)
    {
        _context.Add(playerToAdd);
        _context.SaveChanges();

        return playerToAdd;
    }
    
    public List<Category> GetAllCategories()
    {
        return _context.Categories.Include(r => r.WallPosts).Select(r => r).ToList();
    }
    public Category GetCategoryById(int ID)
    {
        return _context.Categories.Include(r => r.WallPosts).FirstOrDefault(r => r.ID == ID);
    }
    public void AddCategory(Category catToAdd)
    {
        _context.Add(catToAdd);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
    public void DeleteCategory(Category catToDelete)
    {
        _context.Remove(catToDelete);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public List<Category> SearchCategories(string searchTerm)
    {
        return _context.Categories.Where(x => x.CategoryName.ToLower().Contains(searchTerm.ToLower())).ToList();
    }
     
    public void AddDrawing(Drawing drawingToAdd){
        _context.Add(drawingToAdd);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public Drawing GetDrawingByID(int DrawingID){
        return  _context.Drawings
        .Include(r => r.Likes)
        .FirstOrDefault(r => r.ID == DrawingID);
    }
       
    public List<Drawing> GetAllDrawingsByUserID(int PlayerID){
        return _context.Drawings
        .Include(r => r.Likes)
        .AsNoTracking()
        .Where(r => r.PlayerID == PlayerID)
        .ToList();
        // return new List<Drawing>();
    }   
    public List<Drawing> GetAllDrawingsByWallPostID(int WallPostID){
        return _context.Drawings
        .Include(r => r.Likes)
        .AsNoTracking()
        .Where(r => r.WallPostID == WallPostID)
        .ToList();
        // return new List<Drawing>();
    }

    public void DeleteDrawingByID(int DrawingID){
        Drawing drawing = GetDrawingByID(DrawingID);
        _context.Remove(drawing);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void AddWallpost(WallPost wallpostToAdd) {
        _context.Add(wallpostToAdd);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public WallPost GetWallpostByID(int WallpostID) {
        return _context.WallPosts.Include(r => r.Drawings).AsNoTracking().FirstOrDefault(r => r.ID == WallpostID);
    }

    public List<WallPost> GetAllWallpostByCategoryID(int CategoryID) {
        return _context.WallPosts.Include(r => r.Drawings).AsNoTracking().Where(r => r.CategoryID == CategoryID).ToList();
    }

    public WallPost GetWallpostByKeyword(string Key) {
        return _context.WallPosts.Include(r => r.Drawings).AsNoTracking().FirstOrDefault(r => r.Keyword == Key);
    }

    public void DeleteWallpostByID(int WallpostID) {
        WallPost wallpost = GetWallpostByID(WallpostID);
        _context.Remove(wallpost);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public Player GetPlayerByID(int playerID)
    {
        return _context.Players.AsNoTracking().FirstOrDefault(r => r.ID ==playerID);
    }

    public async Task<Player?> GetPlayerByIDWithDrawingsAsync(int playerID)
    {
        return _context.Players.Include("Drawings").FirstOrDefault(r => r.ID == playerID);
    }

    public void DeletePlayerByID(int PlayerID)
    {
        Player player = GetPlayerByID(PlayerID);
        _context.Remove(player);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public List<Player> GetAllPlayers()
    {
        return _context.Players.Select(r => r).ToList();
    }

    public Task<List<Player>> GetAllPlayersWithDrawingsAsync()
    {
        return _context.Players.Include(r => r.Drawings).AsNoTracking().Select(r => r).ToListAsync(); ;
    }

    public Player LoginPlayer(Player player)
    {
        return _context.Players.FirstOrDefault(r => r.Username == player.Username && r.Password == player.Password);
    }
} 

