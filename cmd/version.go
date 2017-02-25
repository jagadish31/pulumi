// Copyright 2016 Pulumi, Inc. All rights reserved.

package cmd

import (
	"fmt"

	"github.com/spf13/cobra"
)

const version = "0.0.1" // TODO[pulumi/coconut#13]: a real auto-incrementing version number.

func newVersionCmd() *cobra.Command {
	return &cobra.Command{
		Use:   "version",
		Short: "Print Coconut's version number",
		Run: func(cmd *cobra.Command, args []string) {
			fmt.Printf("Coconut version %v\n", version)
		},
	}
}
