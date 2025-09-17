package newsHandler

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"main.go/schema"
)

func GetNews(ctx *gin.Context) {
	id := ctx.Query("id")
	if id == ""{
		sendErr(ctx, http.StatusBadRequest, errParamIsRequired("id", "queryParameter").Error())
		return
	}

	news := schema.News{}
	if err := db.First(&news, id).Error;err != nil {
		sendErr(ctx, http.StatusNotFound, "get not found")
		return
	}
	sendSucces(ctx, "get-news", news)
}