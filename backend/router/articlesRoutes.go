package router

import (
	"github.com/gin-gonic/gin"
	articleshandlers "main.go/handler/articlesHandlers"
)

func articlesRoutes(router *gin.Engine, basePath string) {
	v1 := router.Group(basePath)
	{
		v1.GET("/article", articleshandlers.GetArticle)
		v1.GET("/listarticles", articleshandlers.ListArticles)
		v1.POST("/article", articleshandlers.CreateArticle)
		v1.DELETE("/article", articleshandlers.DeleteArticle)
		v1.PATCH("/article", articleshandlers.UpdateArticle)
	}
}