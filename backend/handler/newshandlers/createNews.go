package newsHandler

import (
	"fmt"

	"github.com/gin-gonic/gin"
)

// @BasePath /api/v1

// @Summary Create News
// @Description Create a news for the app
// @Tags Openings
// @Accept json
// @Produce json
// @Param request body CreateNewsObject true "Request Body"
// @Success 201
// @Failure 400
// @Failure 500
// @Router /news [post]
func CreateNews(ctx *gin.Context) {
	fmt.Println("FUNCIONOU")
}