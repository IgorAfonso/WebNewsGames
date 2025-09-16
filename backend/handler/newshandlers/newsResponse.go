package newsHandler

import (
	"fmt"
	"net/http"
	"time"

	"github.com/gin-gonic/gin"
)

func sendErr(ctx *gin.Context, code int, msg string) {
	ctx.Header("Content-Type", "application/json")
	ctx.JSON(code, gin.H{
		"msg":       msg,
		"errorCode": code,
	})
}

func sendPostSucces(ctx *gin.Context, op string, data interface{}) {
	ctx.Header("Content-Type", "application/json")
	ctx.JSON(http.StatusCreated, gin.H{
		"message": fmt.Sprintf("operation %s successful", op),
		"data":    data,
	})
}

func sendSucces(ctx *gin.Context, op string, data interface{}) {
	ctx.Header("Content-Type", "application/json")
	ctx.JSON(http.StatusOK, gin.H{
		"message": fmt.Sprintf("operation %s successful", op),
		"data":    data,
	})
}

type ErrorResponse struct {
	Message   string `json:"message"`
	ErrorCode string `json:"errorCode"`
}

type CreateNewsResponse struct {
	CreatedAt     time.Time `json:"createdAt"`
	UpdatedAt     time.Time `json:"updatedAt"`
	Title         string    `json:"title"`
	FirstContent  string    `json:"firstContent"`
	SecondContent string    `json:"secondContent"`
	ThirdContent  string    `json:"thirdContent"`
}
