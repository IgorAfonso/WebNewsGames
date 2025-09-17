package newsHandler

import (
	"fmt"
	"net/http"

	"github.com/gin-gonic/gin"
	"main.go/schema"
)

// @BasePath /api/v1

// @Summary Delete news
// @Schemas
// @Description Delete a news
// @Tags Openings
// @Accept json
// @Produce json
// @Param id query string true "News identification"
// @Success 200 {object} DeleteNewsResponse
// @Failure 400 {object} ErrorResponse
// @Failure 404 {object} ErrorResponse
// @Router /opening [delete]
func DeleteNews(ctx *gin.Context) {
	id := ctx.Query("id")
	if id == ""{
		sendErr(ctx, http.StatusBadRequest, errParamIsRequired("id", "queryParameter").Error())
		return
	}

	news := schema.News{}
	if err := db.First(&news, id).Error; err != nil {
		sendErr(ctx, http.StatusNotFound, fmt.Sprintf("opening with id: %s not found", id))
		return
	}

	if err := db.Delete(&news).Error; err != nil {
		sendErr(ctx, http.StatusInternalServerError, 
			fmt.Sprintf("error deleting news with id: %s", id))
			return
	}

	sendSucces(ctx, "delete-news", news)
}