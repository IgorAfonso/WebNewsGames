package config

import (
	"fmt"

	"gorm.io/gorm"
)

var (
	db *gorm.DB
)

func Init() error {
	var err error
	db, err = InitializePostgres()
	if err != nil {
		return fmt.Errorf("error initializing sqlite: %v", err)
	}
	return nil
}

func GetPostgres() *gorm.DB{
	return db
}