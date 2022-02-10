using Models;
namespace BL;

public interface IBL
{   
    void AddLike(Like like);

    Like GetLikeByID(int likeID);

    List<Like> GetLikesByPlayerID(int playerID);

    List<Like> GetLikesByDrawingID(int drawingID);

    List<Like> GetLikesByCommentID(int commentID);

    void DeleteLikeByID (int likeID);

    //Comments
    void AddComment(Comment commentToAdd);

    Comment GetCommentByID(int commentID);

    List<Comment> GetCommentsByDrawingID(int drawingID);

    Comment EditCommentByID(int commentID, string message);

    void DeleteCommentByID(int commentID);

    //Categories
    List<Category> GetAllCategories();

    Category GetCategoryByID(int categoryID);
    void AddCategory(Category catToAdd);

    void DeleteCategory(int categoryID);

    List<Category> SearchCategories(string searchTerm);

    //Drawings
    void AddDrawing(Drawing drawingToAdd);

    void UpdateDrawing(Drawing drawingToUpdate);

    Drawing GetDrawingByID(int drawingID);

    List<Drawing> GetAllDrawings();

    List<Drawing> GetAllDrawingsByPlayerID(int playerID);
  
    List<Drawing> GetAllDrawingsByWallPostID(int wallpostID);

    void DeleteDrawingByID(int drawingID);

    //Wall Posts
    List<WallPost> GetAllWallPosts();
    void AddWallpost(WallPost wallpostToAdd);

    WallPost GetWallpostByID(int wallpostID);

    List<WallPost> GetAllWallpostByCategoryID(int categoryID);

    WallPost GetWallpostByKeyword(string Key);
    void DeleteWallpostByID(int wallpostID);

    //Players
    void AddNewPlayerAccount(Player playerToAdd);

    Player? GetPlayerByIDWithDrawings(int playerID);

    Player? GetPlayerByUsernameWithDrawings(string username);
    void UpdatePlayer(Player playerToUpdate);

    void DeletePlayerByID(int playerID);

    List<Player> GetAllPlayersWithDrawings();

    /*    Player LoginPlayer(string username, string password);*/

    Player LoginPlayer(string username);

    bool IsDuplicate(Player player);
}
