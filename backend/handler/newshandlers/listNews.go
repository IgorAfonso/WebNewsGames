package newsHandler

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"main.go/schema"
)

func ListNews(ctx *gin.Context) {
	news := []schema.News{}

	if err := db.Find(&news).Error; err != nil{
		sendErr(ctx, http.StatusInternalServerError, "error listing news")
		return
	}
	sendSucces(ctx, "list-news", news)
}